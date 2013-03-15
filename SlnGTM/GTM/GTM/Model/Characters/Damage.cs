using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTM.Model.Characters
{
    public class Damage
    {
        #region Properties

        public int Value { get; private set; }
        public DamageType Type { get; private set; }

        #endregion

        #region Constructor

        public Damage(int value, DamageType type)
        {
            Value = value;
            Type = type;
        }

        #endregion
    }
}
