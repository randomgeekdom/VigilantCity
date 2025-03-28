using VigilantCity.Core.Models;

namespace VigilantCity.Core.Services.Interfaces
{
    public interface IIncidentFactory
    {
        void GenerateIncidents(City city);
    }
}