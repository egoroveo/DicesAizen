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

        private void CheckValidEdge(int edge, int leftThreshold, int rightThreshold)
        {
            if (edge <= leftThreshold)
                throw new InvalidEdgeException(edge);

            if (edge >= rightThreshold)
                throw new InvalidEdgeException(edge);
        }

        public int EdgeForHitRoll(int attackerAgility, int attackerReaction, int defenderAgility, int defenderReaction)
        {
            double attackerDexterity = attackerAgility + attackerReaction;
            double defenderDexterity = defenderAgility + defenderReaction;
            int edge = (int)Math.Round(100 * defenderDexterity / (defenderDexterity + attackerDexterity));
            return edge;
        }

        public HitProc HitRoll(int edge)
        {
            CheckValidEdge(edge, settings.CriticalMissProcThreshold, settings.CriticalHitProcThreshold);

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

        public int EdgeForEvasionRoll(int actionPointsLeft)
        {
            return 100 - Math.Max(settings.MaxDodgeChance, actionPointsLeft * settings.DodgeChancePerActionPoint);
        }

        public EvasionProc EvasionRoll(int edge)
        {
            var d100 = RandomGenerator.D100;
            return d100 >= edge ? EvasionProc.Dodged : EvasionProc.Failed;
        }

        public int EdgeForParryRoll(int attackerStrength, int attackerReaction, int defenderStrength, int defenderReaction)
        {
            double attackerBalance = attackerStrength + attackerReaction;
            double defenderBalance = defenderStrength + defenderReaction;
            int edge = (int)Math.Round(100 * defenderBalance / (defenderBalance + attackerBalance));

            return edge;
        }

        public ParryProc ParryRoll(int edge)
        {
            CheckValidEdge(edge, settings.ParryCriticalFailureProcThreshold, settings.ParryCounterstrikeProcThreshold);

            var d100 = RandomGenerator.D100;

            if (d100 <= settings.ParryCriticalFailureProcThreshold)
                return ParryProc.CrilicalFailure;
            if (d100 >= settings.ParryCounterstrikeProcThreshold)
                return ParryProc.Counterstrike;
            return d100 >= edge ? ParryProc.Success : ParryProc.Failure;
        }

        public int EdgeForCounterstrikeRoll(int attackerStrength, int defenderStrength)
        {
            return (int)Math.Round(100 * ((double)attackerStrength) / (((double)attackerStrength) + ((double)defenderStrength)));
        }

        public CounterstrikeProc CounterstrikeRoll(int edge)
        {
            CheckValidEdge(edge, settings.CounterstrikeCriticalFailureProcThreshold, settings.CounterstrikeCriticalSuccessProcThreshold);

            var d100 = RandomGenerator.D100;

            if (d100 >= settings.CounterstrikeCriticalSuccessProcThreshold)
                return CounterstrikeProc.Critical;
            if (d100 <= settings.CounterstrikeCriticalFailureProcThreshold)
                return CounterstrikeProc.CrilicalFailure;
            if (d100 >= edge + settings.CounterstrikeVeryStrongHitProcDifferenceThreshold)
                return CounterstrikeProc.VeryStrong;
            if (d100 <= edge - settings.CounterstrikeWeakHitProcDifferenceThreshold)
                return CounterstrikeProc.Weak;
            return d100 >= edge ? CounterstrikeProc.Strong : CounterstrikeProc.Normal;
        }

        public int EdgeForStrengthRoll(int attackerStrength, int defenderStrength)
        {
            return (int)Math.Round(100 * ((double)attackerStrength) / (((double)attackerStrength) + ((double)defenderStrength)));
        }

        public StrengthProc StrengthRoll(int edge)
        {
            CheckValidEdge(edge, settings.StrengthVeryWeakProcThreshold, settings.StrengthCriticalProcThreshold);

            var d100 = RandomGenerator.D100;

            if (d100 >= settings.CounterstrikeCriticalSuccessProcThreshold)
                return StrengthProc.Critical;
            if (d100 <= settings.CounterstrikeCriticalFailureProcThreshold)
                return StrengthProc.VeryWeak;
            if (d100 >= edge + settings.CounterstrikeVeryStrongHitProcDifferenceThreshold)
                return StrengthProc.VeryStrong;
            if (d100 <= edge - settings.CounterstrikeWeakHitProcDifferenceThreshold)
                return StrengthProc.Weak;
            return d100 >= edge ? StrengthProc.Strong : StrengthProc.Normal;
        }


    }
}
