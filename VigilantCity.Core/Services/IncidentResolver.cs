using VigilantCity.Core.Extensions;
using VigilantCity.Core.Models;
using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.Incidents;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Core.Services
{
    public class IncidentResolver(ICityLoader cityLoader)
    {
        //TODO:
        /*
            Resolve hero incident with the approach given
            Resolve other incidents randomly if they hit 0
            Return alerts for each resolved incident
            Add to "Vigilant Comics" issues
         */

        public async Task ResolveIncidentsAsync(City city, Guid heroIncidentId, List<Approach> approaches)
        {
            var heroIncident = city.Incidents.Single(x => x.Id == heroIncidentId);
            this.ResolveIncident(city, city.PlayerCharacter, heroIncident, approaches);

            foreach (var incident in city.Incidents)
            {
                incident.TimeToResolve--;
                if (incident.TimeToResolve <= 0)
                {
                    city.Incidents.Remove(incident);
                }
            }

            await cityLoader.SaveCityAsync(city);
        }

        private bool ResolveIncident(Character character, Incident incident, List<Approach> approaches)
        {
            incident.ApproachModifiers.TryGetValue(approaches[0], out var approachModifier1);
            incident.ApproachModifiers.TryGetValue(approaches[1], out var approachModifier2);

            var approachModifier = approachModifier1 + approachModifier2;

            var characterRoll = DiceRoller.Roll() + approachModifier;
            var difficultyRoll = incident.DifficultyLevel.Roll;

            var powerSet = character.Powers.GetRandom();

            var powerManifestation = character.PowerManifestations.FirstOrDefault(x => 
            approaches.Contains(x.Approach) &&
            x.DifficultyLevel == incident.DifficultyLevel &&
            x.Power == powerSet);

            return (characterRoll >= difficultyRoll);
        }

        private void ResolveIncident(City city, Character character, Incident incident, List<Approach> approaches)
        {
            var isIncidentResolved = ResolveIncident(city.PlayerCharacter, incident, approaches);
            var description = $"{incident.Type.GetDisplayName()} in {incident.District.GetDisplayName()}";
            city.Incidents.Remove(incident);
            if (isIncidentResolved) 
            {
                character.Reputation += incident.DifficultyLevel.Roll % 5 + 1;
                city.Alerts.Add(city.PlayerCharacter.Alias + " resolved the " + description);
            }
            else
            {
                character.Reputation -= incident.DifficultyLevel.Roll % 5 + 1;
                city.Alerts.Add(city.PlayerCharacter.Alias + " failed to resolve the " + description);
            }
        }
    }
}