using VigilantCity.Core.Models;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Core.Services
{
    public class CityService(ICityLoader CityLoader) : ICityService
    {
        public async Task SwitchHeroAsync(City city, Hero hero)
        {
            city.PlayerHero = hero;
            await CityLoader.SaveCityAsync(city);
        }
    }
}