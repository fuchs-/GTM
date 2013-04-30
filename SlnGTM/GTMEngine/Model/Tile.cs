using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using BXEL.Graphics;

namespace GTMEngine.Model
{
    public class Tile : Sprite
    {
        #region Properties

        public MapLocation Location { get; private set; }

        public TileVertice Vertice { get; private set; }

        private List<TileVertice> AdjacentTiles { get; set; }

        #endregion

        #region Constructors

        public Tile(Texture2D tileTexture, MapLocation location) : base("Tile " + location, tileTexture)
        {
            Location = location;
            AdjacentTiles = new List<TileVertice>();
            Vertice = new TileVertice(location);
        }

        #endregion

        #region Methods

        public void AddAdjacentTile(Tile t)
        {
            AdjacentTiles.Add(t.Vertice);
            Vertice.AddAdjacent(t.Vertice);
        }

        #endregion
    }
}
