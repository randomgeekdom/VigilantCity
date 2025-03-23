using System;
using System.Collections.Generic;
using System.Text;
using VigilantCity.Core.Models;

namespace VigilantCity.Core.Services.Interfaces
{
    public interface ICityLoader
    {
        Task<City?> LoadCityAsync();
        Task SaveCityAsync(City city);
    }
}
