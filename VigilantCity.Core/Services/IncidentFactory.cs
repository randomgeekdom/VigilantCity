using VigilantCity.Core.Extensions;
using VigilantCity.Core.Models;
using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.Incidents;
using VigilantCity.Core.Models.PowerSets;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Core.Services
{
    public partial class IncidentFactory(ICityLoader cityLoader) : IIncidentFactory
    {
        private readonly ICityLoader _cityLoader = cityLoader;
        private readonly Random _random = new();

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

                    if (_random.Next(1, 10) > 7)
                    {
                        city.Incidents.Add(GetIncident(district));
                    }
                }
            }
            while (city.Incidents.Count < 3);
            await _cityLoader.SaveCityAsync(city);
        }

        private Incident GetIncident(District district)
        {
            var incidentType = _random.GetRandom<IncidentType>();
            return incidentType switch
            {
                IncidentType.Kidnapping => new Incident("A child has been kidnapped and the parents are desperate to find them.", IncidentType.Kidnapping, district, DifficultyLevel.List().GetRandom(), _random.Next(6) + 1,
                                        new Dictionary<Approach, int>
                                        {
                            { Approach.Diplomatic, _random.Next(2) },
                            { Approach.Stealthy, _random.Next(2) },
                            { Approach.Swift, _random.Next(-8, -4) },
                            { Approach.Tactical, _random.Next(4) },
                            { Approach.Lethal, _random.Next(-1, 7) }
                                        }),
                IncidentType.Robbery => new Incident("A robbery is occurring and the perpitrators are heavily armed.", IncidentType.Robbery, district, DifficultyLevel.List().GetRandom(), 1,
                        new Dictionary<Approach, int>
                        {
                            { Approach.Diplomatic, _random.Next(-9,0) },
                            { Approach.Stealthy, _random.Next(-5, 2) },
                            { Approach.Swift, _random.Next(5,8) },
                            { Approach.Tactical, _random.Next(-2, 2) },
                            { Approach.Lethal, _random.Next(3) }
                        }),
                IncidentType.Rampage => new Incident("Someone is on a rampage and is causing chaos in the streets.", IncidentType.Rampage, district, DifficultyLevel.List().GetRandom(), 1,
                        new Dictionary<Approach, int>
                        {
                            { Approach.Diplomatic, _random.Next(-7, 10) },
                            { Approach.Stealthy, _random.Next(-8, 4) },
                            { Approach.Swift, _random.Next(2) },
                            { Approach.Tactical, _random.Next(4) },
                            { Approach.Lethal, _random.Next(-1, 3) }
                        }),
                IncidentType.Murder => new Incident("Someone has been murdered. Their death needs to be investigated.", IncidentType.Murder, district, DifficultyLevel.List().GetRandom(), _random.Next(6) + 1,
                        new Dictionary<Approach, int>
                        {
                            { Approach.Diplomatic, _random.Next(2) },
                            { Approach.Stealthy, _random.Next(4) },
                            { Approach.Swift, _random.Next(-2, 1) },
                            { Approach.Tactical, _random.Next(2) },
                            { Approach.Lethal, _random.Next(-5, -2) }
                        }),
                IncidentType.HostageSituation => new Incident("There is a hostage situation currently in progress.", IncidentType.HostageSituation, district, DifficultyLevel.List().GetRandom(), 1,
                        new Dictionary<Approach, int>
                        {
                            { Approach.Diplomatic, _random.Next(4) },
                            { Approach.Stealthy, _random.Next(9) },
                            { Approach.Swift, _random.Next(-5, 5) },
                            { Approach.Tactical, _random.Next(10) },
                            { Approach.Lethal, _random.Next(-3, 4) }
                        }),
                _ => throw new NotImplementedException(),
            };
        }
    }
}