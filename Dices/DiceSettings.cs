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

        public void InitializeDefaultValues()
        {
            CriticalHitProcThreshold = 85;
            CriticalMissProcThreshold = 15;
            AccurateHitProcDifferenceThreshold = 20;
            SeriousMissProcDifferenceThreshold = 20;
            DodgeChancePerActionPoint = 5;
            MaxDodgeChance = 20;
        }


    }
}
