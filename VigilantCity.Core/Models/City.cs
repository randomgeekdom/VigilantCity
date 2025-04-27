using VigilantCity.Core.Extensions;
using VigilantCity.Core.Models.Characters;
using VigilantCity.Core.Models.Incidents;
using VigilantCity.Core.Services;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Core.Models
{
    public record City : Entity
    {
        public required Hero PlayerHero { get; set; }
        public List<Hero> Heroes { get; set; } = [];
        public List<Villain> Villains { get; set; } = [];
        public List<Incident> Incidents { get; set; } = [];
        public List<string> Alerts { get; set; } = [];
        public List<string> History { get; set; } = [];
        public List<Guid> ResolvedIncidentIds { get; set; } = [];

        public void AddAlert(string alert)
        {
            Alerts.Add(alert);
            History.Add(alert);
        }

        public string GetHeroSevereConsequence(Hero hero, Func<Hero> createHero)
        {
            if (hero.PowerManifestations.Count != 0)
            {
                var powerManifestation = hero.PowerManifestations.GetRandom()!;
                hero.PowerManifestations.Remove(powerManifestation);
                return $"{hero}'s powers have been limited because of their failure.";
            }

            if(hero.Powers.Count != 0)
            {
                var power = hero.Powers.GetRandom()!;
                hero.Powers.Remove(power);
                return $"{hero} has lost one of his powers during their failure to resolve the situation.";
            }

            var city = this;
            var message = $" They were killed in the process.";
            if (hero != city.PlayerHero)
            {
                city.Heroes.Remove(hero);
            }
            else
            {
                Hero newPlayerHero;
                if (city.Heroes.Count != 0)
                {
                    newPlayerHero = city.Heroes.GetRandom()!;
                    city.Heroes.Remove(newPlayerHero);
                    city.PlayerHero = newPlayerHero;
                }
                else
                {
                    newPlayerHero = createHero();
                    city.PlayerHero = newPlayerHero;
                }

                message += $" You will now play as {newPlayerHero}.";
            }

            return message;
        }

        public void MarkIncidentResolved(Incident incident)
        {
            this.Incidents.Remove(incident);
            this.ResolvedIncidentIds.Add(incident.Id);
        }
    }
}