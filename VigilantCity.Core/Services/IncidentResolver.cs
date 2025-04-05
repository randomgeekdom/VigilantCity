using VigilantCity.Core.Extensions;
using VigilantCity.Core.Models;
using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.Incidents;
using VigilantCity.Core.Models.SmartEnums;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Core.Services
{
    public class IncidentResolver(ICityLoader cityLoader) : IIncidentResolver
    {
        private readonly Random _random = new();
        //TODO:
        /*
            Add to "Vigilant Comics" issues
            Add randomized vigilantes
            Add civilians (if resolved by civilians, every character's reputation goes down)
         */

        public async Task ResolveIncidentsAsync(City city, Guid heroIncidentId, List<Approach> approaches)
        {
            var heroIncident = city.Incidents.Single(x => x.Id == heroIncidentId);
            this.ResolveIncident(city, city.PlayerHero, heroIncident, approaches);

            foreach (var incident in city.Incidents.ToList())
            {
                incident.TimeToResolve--;
                if (incident.TimeToResolve <= 0)
                {
                    city.Incidents.Remove(incident);
                }
            }

            await cityLoader.SaveCityAsync(city);
        }

        private bool ResolveIncident(Hero hero, Incident incident, List<Approach> approaches)
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

            var heroRoll = DiceRoller.Roll() + modifier;
            var difficultyRoll = incident.DifficultyLevel.Roll;

            return (heroRoll >= difficultyRoll);
        }

        private void ResolveIncident(City city, Hero hero, Incident incident, List<Approach> approaches)
        {
            var isIncidentResolved = ResolveIncident(city.PlayerHero, incident, approaches);
            var description = $"{incident.Type.GetDisplayName()} in {incident.District.GetDisplayName()}";
            city.Incidents.Remove(incident);
            if (isIncidentResolved)
            {
                hero.Reputation += incident.DifficultyLevel.Roll % 5 + 1;
                city.AddAlert(city.PlayerHero.Alias + " resolved the " + description);
            }
            else
            {
                hero.Reputation -= incident.DifficultyLevel.Roll % 5 + 1;
                city.AddAlert(city.PlayerHero.Alias + " failed to resolve the " + description);
            }
        }
    }
}