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
        #region Properties

        private UIPanel Grid { get; set; }
        private Sprite CurrentCharPicture { get; set; }

        #endregion

        #region Methods

        #region Flow Methods

        public void LoadContent(ContentManager contentManager)
        {
            Grid = new UIPanel("Grid", contentManager.Load<Texture2D>(@"Images\HUDGrid"), new Vector2(0, 450));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Grid.Draw(spriteBatch);
        }

        #endregion

        public void ChangeCurrentChar(Texture2D newCharTexture)
        { 
            Sprite newChar = new Sprite("CurrentChar", newCharTexture, new Rectangle(10, 10, 150, 150));
            Grid.RemoveObject(CurrentCharPicture);

            CurrentCharPicture = newChar;
            Grid.AddObject(CurrentCharPicture);
        }

        #endregion
    }
}
