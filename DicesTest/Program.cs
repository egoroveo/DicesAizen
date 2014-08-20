using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dices;

namespace DicesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create new dice and initialize dices with default settings
            Dice dice = new Dice();
            // At any moment we can change settings
            dice.Settings.CriticalHitProcThreshold = 85;

            // Examples of roll
            try
            {
                var proc = dice.HitRoll(10, 5, 17, 15);
                // In the external program we need to make localization class to convert enums to strings
                Console.WriteLine(proc.ToString());
            }
            catch (InvalidEdgeException ex) // In the case if edge is too big or small to conduct roll
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}
