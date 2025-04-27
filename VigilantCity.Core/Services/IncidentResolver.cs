using VigilantCity.Core.Extensions;
using VigilantCity.Core.Models;
using VigilantCity.Core.Models.Characters;
using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.Incidents;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Core.Services
{
    public class IncidentResolver(ICityLoader cityLoader, ICharacterFactory characterFactory) : IIncidentResolver
    {
        private readonly Random _random = new();

        public async Task ResolveIncidentsAsync(City city, Guid heroIncidentId, List<Approach> approaches)
        {
            // Get the incident to be resolved by the player hero
            var heroIncident = city.Incidents.Single(x => x.Id == heroIncidentId);
            ResolveIncident(city, city.PlayerHero, heroIncident, approaches);

            var otherHeroes = city.Heroes.ToList();
            var heroCount = otherHeroes.Count;
            foreach (var incident in city.Incidents.ToList())
            {
                incident.TimeToResolve--;
                if (incident.TimeToResolve <= 0)
                {
                    if (otherHeroes.Count != 0)
                    {
                        var randomHero = otherHeroes.GetRandom() ?? throw new NullReferenceException();
                        ResolveIncident(city, randomHero, incident, approaches);
                        otherHeroes.Remove(randomHero);
                    }
                    else
                    {
                        var createNewHero = _random.NextBool(100 - Math.Min(heroCount, 3));
                        if(createNewHero)
                        {
                            var newHero = characterFactory.CreateRandomHero();
                            city.Heroes.Add(newHero);
                            ResolveIncident(city, newHero, incident, approaches);
                        }
                        else
                        {
                            city.AddAlert($"The {incident.GetFullDescription()} was unresolved by the heroes.  All heroes have their reputation reduced.");
                            city.Heroes.ForEach(x => x.Reputation--); 
                            city.Incidents.Remove(incident);
                        }
                    }
                }
            }

            await cityLoader.SaveCityAsync(city);
        }

        private void ResolveIncident(City city, Hero hero, Incident incident, List<Approach> approaches)
        {
            incident.ApproachModifiers.TryGetValue(approaches[0], out var approachModifier1);
            incident.ApproachModifiers.TryGetValue(approaches[1], out var approachModifier2);

            var modifier = approachModifier1 + approachModifier2;

            var power = hero.Powers.GetRandom();
            var poweredApproach = approaches.GetRandom();

            var powerManifestation = hero.PowerManifestations.FirstOrDefault(x =>
            x.Approach == poweredApproach &&
            x.DifficultyLevel == incident.DifficultyLevel &&
            x.PowerSet == power.PowerSet &&
            x.PowerOrigin == power.PowerOrigin);

            if (powerManifestation != null)
            {
                modifier += incident.DifficultyLevel.Roll;
            }
            else
            {
                var powerRoll = DiceRoller.Roll();
                if (powerRoll >= incident.DifficultyLevel.Roll)
                {
                    modifier += incident.DifficultyLevel.GetModifier();
                    hero.PowerManifestations.Add(new PowerManifestation(poweredApproach, power.PowerOrigin, power.PowerSet!, incident.DifficultyLevel));
                }
                else
                {
                    modifier -= incident.DifficultyLevel.GetModifier();
                }
            }

            var heroBaseRoll = DiceRoller.Roll();
            var heroRoll = heroBaseRoll + modifier;
            var difficultyRoll = incident.DifficultyLevel.Roll;
            var isIncidentResolved = (heroRoll >= difficultyRoll);

            var description = incident.GetFullDescription();
            city.MarkIncidentResolved(incident);
            if (isIncidentResolved)
            {
                var villain = city.Villains.Where(x=>x.Status == VillainStatus.Active).GetRandom();
                if(villain == null)
                {
                    villain = characterFactory.CreateRandomVillain();
                    city.Villains.Add(villain);
                }

                if (approaches.Contains(Approach.Lethal))
                {
                    villain.Status = VillainStatus.Dead;
                    city.AddAlert($"{hero} resolved the {description}.  The mastermind appeared to be {villain} and was killed in the process.");
                }
                else
                {
                    villain.Status = VillainStatus.Imprisoned;
                    city.AddAlert($"{hero} resolved the {description}.  The mastermind appeared to be {villain} and was imprisoned.");
                }

                hero.Reputation += incident.DifficultyLevel.Roll % 5 + 1;
            }
            else
            {
                hero.Reputation -= incident.DifficultyLevel.Roll % 5 + 1;

                if(heroBaseRoll <= 1)
                {
                    var consequence = city.GetHeroSevereConsequence(hero, characterFactory.CreateRandomHero);
                }

                var alert = $"{hero} failed to resolve the {description}.";
                city.AddAlert(alert);
            }
        }
    }
}