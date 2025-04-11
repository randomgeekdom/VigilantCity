using VigilantCity.Core.Models;
using VigilantCity.Core.Models.Characters;

namespace VigilantCity.Core.Services.Interfaces
{
    public interface ICityStarter
    {
        Task<City> StartAsync(Hero startingHero);
    }
}