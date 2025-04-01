using VigilantCity.Core.Models;
using VigilantCity.Core.Models.Enumerations;

namespace VigilantCity.Core.Services.Interfaces
{
    public interface IIncidentResolver
    {
        Task ResolveIncidentsAsync(City city, Guid heroIncidentId, List<Approach> approaches);
    }
}