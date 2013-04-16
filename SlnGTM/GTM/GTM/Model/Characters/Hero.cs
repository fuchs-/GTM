using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;

using BXEL.Graphics;

namespace GTM.Model.Characters
{
    public class Hero : Entity
    {
        #region Properties

        private Statistics LevelUpStats { get; set; }

        #endregion

        #region Constructors

        public Hero(string name, Texture2D texture, Statistics baseStats) : base(name, texture, baseStats)
        {
            LevelUpStats = new Statistics();
        }

        public Hero(string name, Texture2D texture) : base(name, texture)
        {
            LevelUpStats = new Statistics();
        }

        #endregion
    }
}
