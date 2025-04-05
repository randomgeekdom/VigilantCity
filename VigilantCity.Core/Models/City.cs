using VigilantCity.Core.Models.Incidents;

namespace VigilantCity.Core.Models
{
    public record City : Entity
    {
        public required Hero PlayerHero { get; set; }
        public List<Hero> Heroes { get; set; } = [];
        public List<Incident> Incidents { get; set; } = [];
        public List<string> Alerts { get; set; } = [];
        public List<string> History { get; set; } = [];

        public void AddAlert(string alert)
        {
            Alerts.Add(alert);
            History.Add(alert);
        }
    }
}