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
using GTMEngine.UI;

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

        public TurnController TurnController { get; private set; }

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

        public void Initialize(Team redTeam, Team blueTeam, TurnController turnController)
        {
            TurnController = turnController;

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

            TurnStarted();
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
                    
                    if (InputController.IsMouseInside(MapRectangle) && InputController.RightMouseButtonClicked())
                    {
                        Tile source, destination;
                        MapLocation l;

                        l = TurnController.CurrentTurn.CurrentHero.Location;
                        source = Tiles[l.X, l.Y];

                        destination = GetTileAtPoint(InputController.GetMousePosition());

                        int length = GetDistance(source, destination);

                        Console.WriteLine(length);

                        if (length > 0 && length <= TurnController.CurrentTurn.CurrentHero.Stats.MovementSpeed && !TurnController.CurrentTurn.CurrentHero.HasMoved)
                        {
                            Console.WriteLine("Possible route:");

                            Path p = GetPath(source, destination);

                            TurnController.CurrentTurn.CurrentHero.Move(p);
                            FlowController.CurrentGameState = GameFlowState.EntityMoving;

                        }
                        else
                        {
                            if (length == -1)
                            {
                                Entity e = GetEntityAtLocation(destination.Location);
                                if (e != null && TurnController.CurrentTurn.CurrentTeam.Color != e.MyPlayer.CurrentTeam.Color)
                                {
                                    destination.RestoreAdjacencies();
                                    AddToGraph(destination);

                                    if (GetDistance(source, destination) <= TurnController.CurrentTurn.CurrentHero.Stats.AttackRange)
                                    {
                                        Damage d = TurnController.CurrentTurn.CurrentHero.Attack(e);
                                        if(d != null) TextController.ShowDamageText(d, GetTileAtLocation(e.Location));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not enough attack range");
                                    }

                                    RemoveFromGraph(destination);
                                }
                                else
                                {
                                    Console.WriteLine("Not an enemy");                                    
                                }
                            }

                            if (length > TurnController.CurrentTurn.CurrentHero.Stats.MovementSpeed) Console.WriteLine("Not enough movement speed");
                            if (TurnController.CurrentTurn.CurrentHero.HasMoved) Console.WriteLine("This hero has already moved this turn");
                        }
                    }
                    
                    break;

                case GameFlowState.EntityMoving:

                    foreach (Entity e in Entities)
                        e.Update(gameTime);
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

        public Vector2 GetScreenPosition(MapLocation location)
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
                if (location == e.Location)
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

        public Tile GetTileAtLocation(MapLocation location)
        {
            return Tiles[location.X, location.Y];
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

        private int GetDistance(Tile source, Tile destination)
        {
            BreadthFirstSearch bfs = new BreadthFirstSearch(TileGraph);

            return bfs.SearchForVerticeFromVertice(source.Vertice, destination.Vertice);
        }

        private Path GetPath(Tile source, Tile destination)
        {
            BreadthFirstSearch bfs = new BreadthFirstSearch(TileGraph);
            return bfs.GetPath(source.Vertice, destination.Vertice);
        }

        public void TurnStarted()
        {
            MapLocation l = TurnController.CurrentTurn.CurrentHero.Location;
            Tile t = GetTileAtLocation(l);
            t.RestoreAdjacencies();
            AddToGraph(t);
        }

        public void TurnEnded(Hero hero)
        {
            MapLocation l = TurnController.CurrentTurn.CurrentHero.Location;
            RemoveFromGraph(GetTileAtLocation(l));
        }

        #endregion
    }
}
