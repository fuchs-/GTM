using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BXEL.Graphics;

namespace GTM.Model.Characters
{
    class Entity : Sprite
    {
        #region Properties

        public MapLocation Location { get; private set; }

        #endregion
    }
}
