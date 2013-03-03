using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using BXEL.Graphics;

namespace GTM.Model
{
    public class Tile : Sprite
    {
        #region Properties

        public MapLocation Location { get; private set; }

        #endregion

        #region Constructors

        public Tile(Texture2D tileTexture, MapLocation location) : base("Tile " + location, tileTexture)
        {
            Location = location;

        }

        #endregion
    }
}
