using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

using BXEL.Graphics;
using BXEL.DataStructures;

using GTMEngine.Model.Characters;
using GTMEngine.Controller;
using GTMEngine.Controller.GameFlow;

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

        public Rectangle MapRectangle { get; private set; }

        private Graph TileGraph { get; set; }

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

            TileGraph = new Graph();
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

                SetEntityLocation(current, new MapLocation(0, 2 + 2*i));
                Entities.Add(current);

                enumerator.MoveNext();
            }


            heroes = blueTeam.GetHeroes();

            enumerator = heroes.GetEnumerator();
            enumerator.MoveNext();

            for (int i = 0; i < heroes.Count; i++)
            {
                current = enumerator.Current;

                SetEntityLocation(current, new MapLocation(15, 2 + 2 * i));
                Entities.Add(current);

                enumerator.MoveNext();
            }

            MapRectangle = new Rectangle(0, 0, X * TileSize.X, Y * TileSize.Y);

            foreach (Tile t in Tiles)
            {
                SetAdjacentTiles(t);
                TileGraph.AddVertice(t.Vertice);
            }

            MapLocation l;

            foreach (Entity e in Entities)
            {
                l = e.Location;
                RemoveFromGraph(Tiles[l.X, l.Y]);
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
                    Tiles[x, y].SetPosition(GetScreenPosition(location)); //Set the right position for it
                }
            }
        }

        public void Update(GameTime gameTime)
        { 
            switch(FlowController.CurrentGameState)
            {
                case GameFlowState.WaitingForPlayerAction:
                    Tile t;
                    if (InputController.LeftMouseButtonClicked() && InputController.IsMouseInside(MapRectangle))
                    {
                        t = GetTileAtPoint(InputController.GetMousePosition());
                        t.Color = Color.Red;
                    }
                    if (InputController.RightMouseButtonClicked() && InputController.IsMouseInside(MapRectangle))
                    {
                        t = GetTileAtPoint(InputController.GetMousePosition());
                        t.Color = Color.White;
                    }
                    break;
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
                e.Draw(gameTime, spriteBatch);
            }
        }

        #endregion


        private void SetEntityLocation(Entity e, MapLocation location)
        {
            e.Location = location;
            e.SetNewPosition(GetScreenPosition(location));
        }

        private Vector2 GetScreenPosition(MapLocation location)
        {
            Vector2 ret = Vector2.Zero;

            if (location.X < X && location.Y < Y)
            {
                ret.X = location.X * TileSize.X;
                ret.Y = location.Y * TileSize.Y;
            }

            return ret;
        }

        public Entity GetEntityAtLocation(MapLocation location)
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

        public Entity GetEntityForName(String name)
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

        public Tile GetTileAtPoint(Point p)
        {
            foreach (Tile t in Tiles)
            {
                if (t.Rectangle.Contains(p))
                    return t;
            }

            return null;
        }

        private void SetAdjacentTiles(Tile t)
        {
            //Left
            if (t.Location.X > 0) t.AddAdjacentTile(Tiles[t.Location.X - 1, t.Location.Y]);
            //Right
            if (t.Location.X < X - 1) t.AddAdjacentTile(Tiles[t.Location.X + 1, t.Location.Y]);
            //Up
            if (t.Location.Y > 0) t.AddAdjacentTile(Tiles[t.Location.X, t.Location.Y - 1]);
            //Down
            if (t.Location.Y < Y - 1) t.AddAdjacentTile(Tiles[t.Location.X, t.Location.Y + 1]);
        }

        private void AddToGraph(Tile t)
        {
            TileGraph.AddVertice(t.Vertice);
        }

        private void RemoveFromGraph(Tile t)
        {
            TileGraph.RemoveVertice(t.Vertice);
        }

        #endregion
    }
}
