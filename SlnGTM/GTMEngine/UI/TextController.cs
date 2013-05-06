using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using BXEL.Graphics;

using GTMEngine.Model;
using GTMEngine.Model.Characters;

namespace GTMEngine.UI
{
    public static class TextController
    {
        #region Properties

        private static SpriteFont DamageFont { get; set; }
        private static SpriteText DamageText { get; set; }
        private static bool IsDrawingDamageText { get; set; }
        private static int DamageTextCount { get; set; }

        #endregion

        #region Methods

        public static void Initialize(ContentManager contentManager)
        {
            DamageFont = contentManager.Load<SpriteFont>(@"Fonts\DamageFont");
            IsDrawingDamageText = false;
            DamageTextCount = 0;
        }

        public static void ShowDamageText(Damage damage, Tile tile)
        {
            string text = "-" + damage.Value;
            Vector2 p = tile.Position;
            p.X += 7;
            DamageText = new SpriteText(text, DamageFont, Color.Red, p);
            IsDrawingDamageText = true;
        }

        public static void Update(GameTime gameTime)
        {
            if (IsDrawingDamageText)
            {
                DamageTextCount++;
                DamageText.SetPosition(DamageText.Position - new Vector2(0, 1));
                if (DamageTextCount == 20)
                {
                    IsDrawingDamageText = false;
                    DamageTextCount = 0;
                    DamageText = null;
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (IsDrawingDamageText) DamageText.Draw(spriteBatch);
        }

        #endregion
    }
}
