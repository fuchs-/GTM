using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using BXEL.Graphics;

namespace GTM.Model.Characters
{
    public class Entity : Sprite
    {
        #region Properties

        public MapLocation Location { get; private set; }

        public Statistics Stats { get; private set; }

        #endregion

        #region Constructors

        public Entity(String name, Texture2D texture) : base(name, texture)
        {
            Location = new MapLocation();
            Stats = new Statistics();
        }

        #endregion
    }
}
