using VigilantCity.Core.Models.Characters;

namespace VigilantCity.Core.Services.Interfaces
{
    public interface IHeroFactory
    {
        Hero CreateRandomHero();
    }
}