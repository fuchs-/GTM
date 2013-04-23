﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using BXEL.Graphics;

using GTMEngine.Model.Characters;

namespace GTMEngine.Model
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
        private List<Entity> Entities { get; set; }

        //Holds all the effects currently on the map
        //private List<Effect> Effects { get; set; }

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
            Entities = new List<Entity>();
        }

        #endregion

        #region Methods

        #region Flow Methods

        public void Initialize(Team redTeam, Team blueTeam)
        {
            List<Hero> heroes;
            List<Hero>.Enumerator enumerator;
            Hero current = null;

            heroes = redTeam.GetHeroes();

            enumerator = heroes.GetEnumerator();
            enumerator.MoveNext();

            for (int i = 0; i < heroes.Count; i++)
            {
                current = enumerator.Current;

                setEntityLocation(current, new MapLocation(0, i));
                Entities.Add(current);

                enumerator.MoveNext();
            }


            heroes = blueTeam.GetHeroes();

            enumerator = heroes.GetEnumerator();
            enumerator.MoveNext();

            for (int i = 0; i < heroes.Count; i++)
            {
                current = enumerator.Current;

                setEntityLocation(current, new MapLocation(2, i));
                Entities.Add(current);

                enumerator.MoveNext();
            }
        }

        public void LoadContent(ContentManager contentManager)
        {
            MapLocation location;
            TileTexture = contentManager.Load<Texture2D>("Images\\emptyTile");
            TileSize = Size.GetSize(TileTexture);

            for (int x = 0; x < X; x++)     // For each column
            {
                for (int y = 0; y < Y; y++) // For each line
                {
                    location = new MapLocation(x, y);
                    Tiles[x, y] = new Tile(TileTexture, location);      //Load the tile
                    Tiles[x, y].Position = getScreenPosition(location); //Set the right position for it
                }
            }
        }

        public void Update(GameTime gameTime)
        { 
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
                e.Draw(gameTime, spriteBatch);
            }
        }

        #endregion

        private void setEntityLocation(Entity e, MapLocation location)
        {
            e.Location = location;
            e.SetNewPosition(getScreenPosition(location));
        }

        private Vector2 getScreenPosition(MapLocation location)
        {
            Vector2 ret = Vector2.Zero;

            if (location.X < X && location.Y < Y)
            {
                ret.X = location.X * TileSize.X;
                ret.Y = location.Y * TileSize.Y;
            }

            return ret;
        }

        public Entity getEntityAtLocation(MapLocation location)
        {
            Entity ret = null;

            foreach (Entity e in Entities)
            {
                if (e.Location == location)
                {
                    ret = e;
                    break;
                }
            }

            return ret;
        }

        public Entity getEntityForName(String name)
        {
            Entity ret = null;

            foreach (Entity e in Entities)
            {
                if (e.Name == name)
                {
                    ret = e;
                    break;
                }
            }

            return ret;
        }

        #endregion
    }
}