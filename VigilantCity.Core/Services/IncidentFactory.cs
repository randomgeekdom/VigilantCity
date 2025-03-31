using System.Formats.Asn1;
using VigilantCity.Core.Extensions;
using VigilantCity.Core.Models;
using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.Incidents;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Core.Services
{
    public class IncidentFactory(ICityLoader cityLoader) : IIncidentFactory
    {
        private readonly Random _random = new();
        private readonly ICityLoader _cityLoader = cityLoader;

        public async Task GenerateIncidents(City city)
        {
            do
            {
                foreach (var district in Enum.GetValues<District>())
                {
                    if (city.Incidents.Any(x => x.District == district))
                    {
                        continue;
                    }

                    if(_random.Next(1, 10) > 7)
                    {
                        var incidentType = _random.GetRandom<IncidentType>();
                        var description = incidentType.GetIncidentText();
                        var timeToResolve = incidentType.GetIncidentTimeToResolve();

                        city.Incidents.Add(new Incident(description, incidentType, district, timeToResolve));
                    }
                }
            }
            while (city.Incidents.Count < 3);
            await _cityLoader.SaveCityAsync(city);
        }
    }

    public class IncidentResolver(ICityLoader cityLoader)
    {
        //TODO:
        /*
            Resolve hero incident with the approach given
            Resolve other incidents randomly if they hit 0
            Return alerts for each resolved incident
            Add to "Vigilant Comics" issues
         */


        public async Task ResolveIncidentsAsync(City city, Guid heroIncidentId, Approach approach)
        {
            var heroIncident = city.Incidents.FirstOrDefault(x => x.Id == heroIncidentId);

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
    }
}