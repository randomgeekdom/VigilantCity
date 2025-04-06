﻿using RandomNameGeneratorLibrary;
using VigilantCity.Core.Extensions;
using VigilantCity.Core.Models;
using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.SmartEnums;
using VigilantCity.Core.Services.Interfaces;

namespace VigilantCity.Core.Services
{
    public class HeroFactory : IHeroFactory
    {
        private readonly Random _random = new();

        public Hero CreateRandomHero()
        {
            var firstName = _random.GenerateRandomFirstName();
            var lastName = _random.GenerateRandomLastName();
            var powerSet = PowerSet.List().GetRandom();
            var powerOrigin = _random.GetRandom<PowerOrigin>();

            return new Hero
            {
                Alias = powerSet.GetName(),
                Powers = [new Power { PowerOrigin = powerOrigin, PowerSet = powerSet }],
                RealName = $"{firstName} {lastName}",
                Reputation = _random.Next(1, 10),
            };
        }
    }
}