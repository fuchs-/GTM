using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using BXEL.Graphics;

namespace GTM.Model
{
    public class Map
    {
        #region Properties

        int X, Y;
        private Tile[,] Tiles { get; set; }
        private Texture2D TileTexture { get; set; }
        private Size TileSize { get; set; }

        #endregion

        #region Constructor

        public Map()
        {
            X = 30;
            Y = 15;
            Tiles = new Tile[X, Y];
        }

        #endregion

        #region Methods

        #region Flow Methods

        public void LoadContent(ContentManager contentManager)
        {
            TileTexture = contentManager.Load<Texture2D>("emptyTile");
            TileSize = Size.GetSize(TileTexture);

            for (int x = 0; x < X; x++)
            {
                for (int y = 0; y < Y; y++)
                {
                    Tiles[x, y] = new Tile(TileTexture, new MapLocation(x, y));
                    Tiles[x, y].Position = getScreenPosition(x, y);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Tile t in Tiles)
            {
                t.Draw(spriteBatch);
            }
        }

        #endregion

        public Vector2 getScreenPosition(int x, int y)
        {
            Vector2 ret = new Vector2();

            if (x < X && y < Y)
            {
                ret.X = x * TileSize.X;
                ret.Y = y * TileSize.Y;
            }

            return ret;
        }

        #endregion
    }
}
