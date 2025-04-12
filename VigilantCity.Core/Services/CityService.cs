using VigilantCity.Core.Models;
using VigilantCity.Core.Models.Characters;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Core.Services
{
    public class CityService(ICityLoader CityLoader) : ICityService
    {
        /// <summary>
        /// Switch the player hero with another hero in the city.
        /// </summary>
        /// <param name="city"></param>
        /// <param name="hero"></param>
        /// <returns></returns>
        public async Task SwitchHeroAsync(City city, Hero hero)
        {
            city.Heroes.Add(city.PlayerHero);
            city.PlayerHero = hero;
            city.Heroes.Remove(hero);
            await CityLoader.SaveCityAsync(city);
        }
    }
}