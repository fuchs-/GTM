using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using BXEL.Graphics;

using GTM.Model.Characters;

namespace GTM.Model
{
    public class Map
    {
        #region Properties

        private int X, Y; // These represent the number of columns and lines on the map respectively

        #region Tiles

        // Set of tiles
        private Tile[,] Tiles { get; set; } 
        //The texture for each tile
        private Texture2D TileTexture { get; set; } 
        //Size of each tile
        private Size TileSize { get; set; }

        #endregion

        //Holds all the entities currently on the map
        private Entity[,] Entities { get; set; }

        #endregion

        #region Constructor

        public Map()
        {
            // Setting the size of the map
            X = 16; //Columns
            Y = 9;  //Lines

            //Setting tile's matrix
            Tiles = new Tile[X, Y];

            //Setting entitie's matrix
            Entities = new Entity[X, Y];
        }

        #endregion

        #region Methods

        #region Flow Methods

        public void LoadContent(ContentManager contentManager)
        {
            MapLocation location;
            TileTexture = contentManager.Load<Texture2D>("emptyTile");
            TileSize = Size.GetSize(TileTexture);

            for (int x = 0; x < X; x++)     // For each column
            {
                for (int y = 0; y < Y; y++) // For each line
                {
                    location = new MapLocation(x, y);
                    Tiles[x, y] = new Tile(TileTexture, location); //Load the tile
                    Tiles[x, y].Position = getScreenPosition(location);             //Set the right position for it
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //Drawing tiles
            foreach (Tile t in Tiles)
            {
                t.Draw(spriteBatch);
            }

            //Drawing entities
            foreach (Entity e in Entities)
            {
                if(e != null) e.Draw(spriteBatch);
            }
        }

        #endregion

        public Vector2 getScreenPosition(MapLocation location)
        {
            Vector2 ret = new Vector2();

            if (location.X < X && location.Y < Y)
            {
                ret.X = location.X * TileSize.X;
                ret.Y = location.Y * TileSize.Y;
            }

            return ret;
        }

        public Entity getEntityAtLocation(MapLocation location)
        {
            return Entities[location.X, location.Y];
        }

        #endregion
    }
}
