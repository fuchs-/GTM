using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BXEL.Graphics;

namespace GTM.Model.Characters
{
    public abstract class Effect
    {
        #region Properties

        public String Description { get; private set; }
        public Sprite Image { get; private set; }

        #endregion

        #region Constructors

        public Effect()
        {
            Description = String.Empty;
            Image = null;
        }

        public Effect(String description, Sprite image)
        {
            Description = description;
            Image = image;
        }

        #endregion

        #region Properties

        public int DamageToDeal(int damage, DamageType type)
        {
            return damage;
        }

        public bool AllowToAttack()
        {
            return true;
        }

        public bool AllowToCastSpell()
        {
            return true;
        }        

        #endregion
    }
}
