using VigilantCity.Core.Extensions;
using VigilantCity.Core.Models;
using VigilantCity.Core.Models.Incidents;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Core.Services
{
    public class IncidentFactory : IIncidentFactory
    {
        private readonly Random _random = new();
        public void GenerateIncidents(City city)
        {
            foreach (var district in Enum.GetValues<District>())
            {
                if (city.Incidents.Any(x => x.District == district))
                {
                    continue;
                }

                for (int i = 0; i < _random.Next(1, 5); i++)
                {
                    var type = _random.GetRandom<IncidentType>();
                    var description = type switch
                    {
                        IncidentType.Rampage => "Someone is on a rampage",
                        IncidentType.Robbery => "A robbery is in progress",
                        _ => "An incident is in progress"
                    };

                    city.Incidents.Add(new Incident(description, type, district));
                }
            }
        }
    }
}