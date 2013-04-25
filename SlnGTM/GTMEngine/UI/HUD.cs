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

        private static Texture2D energyBarBox;
        private static Texture2D hpBarTexture;
        private static Texture2D mpBarTexture;

        #endregion

        #region Static Properties

        public static Vector2 HUDPosition { get { return new Vector2(0, 450); } }
        public static Size HUDSize { get { return new Size(900, 170); } }

        public static Texture2D EnergyBarBox { get { return energyBarBox; } }
        public static Texture2D HPBarTexture { get { return hpBarTexture; } }
        public static Texture2D MPBarTexture { get { return mpBarTexture; } }

        public static Vector2 HPBarPosition { get { return new Vector2(200, 10); } }
        public static Vector2 MPBarPosition { get { return new Vector2(200, 45); } }

        #endregion

        #region Properties

        private Sprite Grid { get; set; }
        private HUDDisplay CurrentHUDDisplay { get; set; }

        #endregion

        #region Methods

        #region Flow Methods

        public static void Initialize(ContentManager contentManager)
        {
            energyBarBox = contentManager.Load<Texture2D>(@"Images\HUD\EnergyBarBox");
            hpBarTexture = contentManager.Load<Texture2D>(@"Images\HUD\HPBar");
            mpBarTexture = contentManager.Load<Texture2D>(@"Images\HUD\MPBar");
        }

        public void LoadContent(ContentManager contentManager)
        {
            Grid = new Sprite("HUDGrid", contentManager.Load<Texture2D>(@"Images\HUD\Grid"), HUDPosition);
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
