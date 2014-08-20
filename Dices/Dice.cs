using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dices
{
    public class Dice
    {
        private DiceSettings settings;

        public DiceSettings Settings
        {
            get
            {
                return settings;
            }
        }

        public Dice()
        {
            settings = new DiceSettings(); 
            settings.InitializeDefaultValues();
        }

        public HitProc HitRoll(int attackerAgility, int attackerReaction, int defenderAgility, int defenderReaction)
        {
            double attackerDexterity = attackerAgility + attackerReaction;
            double defenderDexterity = defenderAgility + defenderReaction;
            int edge = (int) Math.Round(defenderDexterity / (defenderDexterity + attackerDexterity));

            if (edge >= settings.CriticalHitProcThreshold)
                throw new InvalidEdgeException(edge);

            if (edge <= settings.CriticalMissProcThreshold)
                throw new InvalidEdgeException(edge);

            var d100 = RandomGenerator.D100;

            if (d100 >= settings.CriticalHitProcThreshold)
                return HitProc.CriticalHit;
            if (d100 <= settings.CriticalMissProcThreshold)
                return HitProc.CriticalMiss;
            if (d100 >= edge + settings.AccurateHitProcDifferenceThreshold)
                return HitProc.AccurateHit;
            if (d100 <= edge - settings.SeriousMissProcDifferenceThreshold)
                return HitProc.SeriousMiss;
            return d100 >= edge ? HitProc.Hit : HitProc.Miss;
        }

        public EvasionProc EvasionRoll(int actionPointsLeft)
        {
            var dodgeChance = Math.Max(settings.MaxDodgeChance, actionPointsLeft * settings.DodgeChancePerActionPoint);
            var d100 = RandomGenerator.D100;
            return d100 <= dodgeChance ? EvasionProc.Dodged : EvasionProc.Failed;
        }

        public string Result
        {
            get
            {
                return "Result";
            }
        }
    }
}
