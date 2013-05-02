using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BXEL.DataStructures;

namespace GTMEngine.Model
{
    public class TileVertice : Vertice
    {
        #region Properties

        public MapLocation Location { get; private set; }

        #endregion

        #region Constructors

        public TileVertice(MapLocation location) : base(location.ToString())
        {
            Location = location;
        }

        #endregion

        #region Methods

        public override string GenerateVerticeID()
        {
            return Location.ToString();
        }

        public override string ToString()
        {
            return Location.ToString();
        }

        #endregion
    }
}
