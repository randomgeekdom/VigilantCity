using System;
using System.Collections.Generic;
using System.Text;

namespace VigilantCity.Core.Services
{
    public static class DiceRoller
    {
        public static int Roll()
        {
            return new Random().Next(1, 21);
        }
    }
}
