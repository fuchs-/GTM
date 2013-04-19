using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using BXEL.Graphics;

namespace GTMEngine.Model.Characters
{
    public class Inventory : Sprite
    {
        #region Properties

        private Dictionary<int, Item> Items { get; set; }

        #endregion

        #region Constructors

        public Inventory(Texture2D texture)
            : base("Inventory", texture)
        {
            Items.Add(1, null);
            Items.Add(2, null);
            Items.Add(3, null);
            Items.Add(4, null);
            Items.Add(5, null);
            Items.Add(6, null);
        }

        #endregion
    }
}
