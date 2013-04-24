using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BXEL.Graphics;
using BXEL.Graphics.UI;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GTMEngine.UI
{
    public class HUD
    {
        #region Attributes

        public static Vector2 HUDPosition = new Vector2(0, 450);

        #endregion

        #region Properties

        private Sprite Grid { get; set; }
        private HUDDisplay CurrentHUDDisplay { get; set; }

        #endregion

        #region Methods

        #region Flow Methods

        public void LoadContent(ContentManager contentManager)
        {
            Grid = new Sprite("HUDGrid", contentManager.Load<Texture2D>(@"Images\HUDGrid"), HUDPosition);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Grid.Draw(spriteBatch);
            if (CurrentHUDDisplay != null) CurrentHUDDisplay.Draw(spriteBatch);
        }

        #endregion

        public void ChangeHUDDisplay(HUDDisplay newHUDDisplay)
        {
            CurrentHUDDisplay = newHUDDisplay;
        }

        #endregion
    }
}
