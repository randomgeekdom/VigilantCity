using Blazored.LocalStorage;
using VigilantCity.Core.Models;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Blazor.Services
{
    public class CityLoader(ILocalStorageService localStorageService) : ICityLoader
    {
        private readonly ILocalStorageService _localStorageService = localStorageService;

        public async Task<City?> LoadCityAsync()
        {
            return await this._localStorageService.GetItemAsync<City>(nameof(City));
        }

        public async Task SaveCityAsync(City city)
        {
            await this._localStorageService.SetItemAsync(nameof(City), city);
        }
    }
}