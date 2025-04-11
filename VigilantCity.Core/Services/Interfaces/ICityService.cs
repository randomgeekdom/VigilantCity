using VigilantCity.Core.Models;

namespace VigilantCity.Core.Services.Interfaces
{
    public interface ICityService
    {
        Task SwitchHeroAsync(City city, Hero hero);
    }
}