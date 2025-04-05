using VigilantCity.Core.Extensions;
using VigilantCity.Core.Models;
using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.Incidents;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Core.Services
{
    public class IncidentResolver(ICityLoader cityLoader) : IIncidentResolver
    {
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

            var approachModifier = approachModifier1 + approachModifier2;

            var heroRoll = DiceRoller.Roll() + approachModifier;
            var difficultyRoll = incident.DifficultyLevel.Roll;

            var powerSet = hero.Powers.GetRandom();

            var powerManifestation = hero.PowerManifestations.FirstOrDefault(x =>
            approaches.Contains(x.Approach) &&
            x.DifficultyLevel == incident.DifficultyLevel &&
            x.Power == powerSet);

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