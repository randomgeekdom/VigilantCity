using VigilantCity.Core.Models;

namespace VigilantCity.Core.Services.Interfaces
{
    public interface ICityStarter
    {
        Task<City> StartAsync(Hero startingHero);
    }
}