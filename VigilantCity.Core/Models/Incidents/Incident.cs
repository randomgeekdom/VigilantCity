using VigilantCity.Core.Models.Enumerations;

namespace VigilantCity.Core.Models.Incidents
{
    public record Incident : Entity
    {
        public IncidentType Type { get; set; }
        public string Description { get; set; }
        public District District { get; set; }
        public int TimeToResolve { get; set; }

        public Incident(string description, IncidentType type, District district, int timeToResolve = 1)
        {
            this.Description = description;
            this.Type = type;
            this.District = district;
            this.TimeToResolve = timeToResolve;
        }
    }
}