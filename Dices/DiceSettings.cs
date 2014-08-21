using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dices
{
    public class DiceSettings
    {
        public int CriticalHitProcThreshold
        {
            get;
            set;
        }


        public int CriticalMissProcThreshold
        {
            get;
            set;
        }

        public int AccurateHitProcDifferenceThreshold
        {
            get;
            set;
        }

        public int SeriousMissProcDifferenceThreshold
        {
            get;
            set;
        }

        public int DodgeChancePerActionPoint
        {
            get;
            set;
        }

        public int MaxDodgeChance
        {
            get;
            set;
        }

        public int ParryCriticalFailureProcThreshold
        {
            get;
            set;
        }

        public int ParryCounterstrikeProcThreshold
        {
            get;
            set;
        }

        public int CounterstrikeCriticalFailureProcThreshold
        {
            get;
            set;
        }

        public int CounterstrikeCriticalSuccessProcThreshold
        {
            get;
            set;
        }

        public int CounterstrikeVeryStrongHitProcDifferenceThreshold
        {
            get;
            set;
        }

        public int CounterstrikeWeakHitProcDifferenceThreshold
        {
            get;
            set;
        }

        public int StrengthCriticalProcThreshold
        {
            get;
            set;
        }

        public int StrengthVeryWeakProcThreshold
        {
            get;
            set;
        }

        public int StrengthVeryStrongHitProcDifferenceThreshold
        {
            get;
            set;
        }

        public int StrengthWeakHitProcDifferenceThreshold
        {
            get;
            set;
        }

        public void InitializeDefaultValues()
        {
            CriticalHitProcThreshold = 85;
            CriticalMissProcThreshold = 15;
            AccurateHitProcDifferenceThreshold = 20;
            SeriousMissProcDifferenceThreshold = 20;
            DodgeChancePerActionPoint = 5;
            MaxDodgeChance = 20;
            ParryCriticalFailureProcThreshold = 10;
            ParryCounterstrikeProcThreshold = 90;
            CounterstrikeCriticalFailureProcThreshold = 15;
            CounterstrikeCriticalSuccessProcThreshold = 85;
            CounterstrikeVeryStrongHitProcDifferenceThreshold = 15;
            CounterstrikeWeakHitProcDifferenceThreshold = 15;
            StrengthVeryWeakProcThreshold = 15;
            StrengthCriticalProcThreshold = 85;
            StrengthVeryStrongHitProcDifferenceThreshold = 15;
            StrengthWeakHitProcDifferenceThreshold = 15;
        }


    }
}
