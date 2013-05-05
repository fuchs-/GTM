using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTMEngine.Model.Characters
{
    public class Damage
    {
        #region Properties

        public int Value { get; set; }
        public DamageType Type { get; private set; }
        public Entity Source { get; private set; }

        #endregion

        #region Constructor

        public Damage(int value, DamageType type, Entity source)
        {
            Value = value;
            Type = type;
            Source = source;
        }

        #endregion
    }
}
