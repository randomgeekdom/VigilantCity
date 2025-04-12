using VigilantCity.Core.Models.Characters;

namespace VigilantCity.Core.Services.Interfaces
{
    public interface ICharacterFactory
    {
        Hero CreateRandomHero();
        Villain CreateRandomVillain();
    }
}