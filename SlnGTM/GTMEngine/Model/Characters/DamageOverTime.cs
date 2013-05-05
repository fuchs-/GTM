using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTMEngine.Model.Characters
{
    public class DamageOverTime : Damage
    {
        #region Properties

        public int Duration { get; private set; }

        public int CurrentDuration { get; private set; }

        #endregion

        #region Constructors

        public DamageOverTime(int value, DamageType type, Entity source, int duration)
            : base(value, type, source)
        {
            Duration = duration;
            Reset();
        }

        #endregion

        #region Methods

        #region FlowMethods

        public void NextTurn()
        {
            if (CurrentDuration > 0)
                CurrentDuration--;
        }

        #endregion

        public void Reset()
        {
            CurrentDuration = Duration;
        }

        #endregion
    }
}
