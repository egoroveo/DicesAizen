using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dices
{
    class RandomGenerator
    {
        private static System.Random rnd;

        static RandomGenerator()
        {
            rnd = new System.Random();
        }

        public static int D100
        {
            get
            {
                return rnd.Next(99) + 1;
            }
        }
    }
}
