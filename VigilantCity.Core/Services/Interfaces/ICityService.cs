using VigilantCity.Core.Models;
using VigilantCity.Core.Models.Characters;

namespace VigilantCity.Core.Services.Interfaces
{
    public interface ICityService
    {
        Task SwitchHeroAsync(City city, Hero hero);
    }
}