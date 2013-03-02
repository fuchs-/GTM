using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GTM.Model
{
    public class Map
    {
        #region Properties

        private int[,] Tile { get; set; }
        private Texture2D TileTexture { get; set; }

        #endregion

        #region Methods

        public void LoadContent(ContentManager contentManager)
        {
            TileTexture = contentManager.Load<Texture2D>("emptyTile");
        }

        #endregion
    }
}
