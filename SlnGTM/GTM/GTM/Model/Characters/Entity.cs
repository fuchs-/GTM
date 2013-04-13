using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BXEL.Graphics;

namespace GTM.Model.Characters
{
    public class Entity : Sprite
    {
        #region Attributes

        private MapLocation location;

        #endregion

        #region Properties

        public MapLocation Location 
        {
            get { return location; }

            set
            {
                location = value;

                this.Position = new Vector2(location.X * 50, location.Y * 50);

            }
        }

        public Statistics Stats { get; protected set; }

        #endregion

        #region Constructors

        public Entity(String name, Texture2D texture) : base(name, texture, Vector2.Zero, new Size(50, 50))
        {
            Location = new MapLocation();
            Stats = new Statistics();
        }

        #endregion
    }
}
