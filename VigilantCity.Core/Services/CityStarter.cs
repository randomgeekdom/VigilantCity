using System;
using System.Collections.Generic;
using System.Text;
using VigilantCity.Core.Models;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Core.Services
{
    public class CityStarter(ICityLoader cityLoader) : ICityStarter
    {
        public async Task<City> StartAsync(Character startingCharacter)
        {
            var city = new City
            {
                PlayerCharacter = startingCharacter
            };

            await cityLoader.SaveCityAsync(city);

            return city;
        }
    }
}