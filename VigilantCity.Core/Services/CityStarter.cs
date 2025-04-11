using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using VigilantCity.Core.Models;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Core.Services
{
    public class CityStarter(ICityLoader cityLoader) : ICityStarter
    {
        public async Task<City> StartAsync(Hero startingHero)
        {
            var city = new City
            {
                PlayerHero = startingHero
            };

            await cityLoader.SaveCityAsync(city);

            return city;
        }
    }
}