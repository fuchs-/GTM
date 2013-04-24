using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BXEL.Graphics.UI;
using BXEL.Graphics;

using Microsoft.Xna.Framework;

namespace GTMEngine.UI
{
    public class HUDDisplay : UIPanel
    {
        #region Constructors

        public HUDDisplay() : base("HUDDisplay", null, HUD.HUDPosition, new Size(900, 170), Color.White) { }

        #endregion
    }
}
