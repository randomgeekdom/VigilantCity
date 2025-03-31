using VigilantCity.Core.Models;

namespace VigilantCity.Core.Services.Interfaces
{
    public interface IIncidentFactory
    {
        Task GenerateIncidents(City city);
    }
}