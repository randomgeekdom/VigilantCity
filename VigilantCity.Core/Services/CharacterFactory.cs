﻿using RandomNameGeneratorLibrary;
using VigilantCity.Core.Extensions;
using VigilantCity.Core.Models;
using VigilantCity.Core.Models.Characters;
using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.SmartEnums;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Core.Services
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly Random _random = new();

        public Hero CreateRandomHero()
        {
            var firstName = _random.GenerateRandomFirstName();
            var lastName = _random.GenerateRandomLastName();
            var powerSet = PowerSet.List().GetRandom()!;
            var powerOrigin = _random.GetRandom<PowerOrigin>();
            string realName = $"{firstName} {lastName}";

            return new Hero
            {
                Alias = powerSet.GetAlias(realName),
                Powers = [new Power { PowerOrigin = powerOrigin, PowerSet = powerSet }],
                RealName = realName,
                Reputation = _random.Next(1, 10),
            };
        }

        public Villain CreateRandomVillain()
        {
            var firstName = _random.GenerateRandomFirstName();
            var lastName = _random.GenerateRandomLastName();
            var powerSet = PowerSet.List().GetRandom();
            var powerOrigin = _random.GetRandom<PowerOrigin>();
            string realName = $"{firstName} {lastName}";

            if (this._random.NextBool())
            {
                return new Villain
                {
                    Alias = realName,
                    RealName = realName,
                    Status = VillainStatus.Active,
                };
            }
            else
            {
                return new Villain
                {
                    Alias = powerSet.GetAlias(realName),
                    Powers = [new Power { PowerOrigin = powerOrigin, PowerSet = powerSet }],
                    RealName = realName,
                    Status = VillainStatus.Active,
                };
            }
        }
    }
}