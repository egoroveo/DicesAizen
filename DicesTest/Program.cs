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

            // Example of hit roll
            try
            {
                var hitEdge = dice.EdgeForHitRoll(10, 5, 17, 15);
                var hitProc = dice.HitRoll(hitEdge);
                // In the external program we need to make localization class to convert enums to strings
                Console.WriteLine(hitProc.ToString());
            }
            catch (InvalidEdgeException ex) // In the case if edge is too big or small to conduct roll
            {
                Console.WriteLine(ex.ToString());
            }

            // Example of evasion roll
            var evasionEdge = dice.EdgeForEvasionRoll(3);
            var evasionProc = dice.EvasionRoll(evasionEdge);
            // In the external program we need to make localization class to convert enums to strings
            Console.WriteLine(evasionProc.ToString());

            // Example of parry roll
            try
            {
                var parryEdge = dice.EdgeForParryRoll(25, 30, 20, 25);
                var parryProc = dice.ParryRoll(parryEdge);
                // In the external program we need to make localization class to convert enums to strings
                Console.WriteLine(parryProc.ToString());
            }
            catch (InvalidEdgeException ex) // In the case if edge is too big or small to conduct roll
            {
                Console.WriteLine(ex.ToString());
            }


            Console.ReadKey();
        }
    }
}
