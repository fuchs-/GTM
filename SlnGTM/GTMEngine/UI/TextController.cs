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

        private static SpriteText LevelUpText { get; set; }
        private static bool IsDrawingLevelUpText { get; set; }
        private static int LevelUpTextCount { get; set; }

        private static float TileTextXSpacing { get; set; }

        #endregion

        #region Methods

        public static void Initialize(ContentManager contentManager)
        {
            DamageFont = contentManager.Load<SpriteFont>(@"Fonts\DamageFont");
            IsDrawingDamageText = false;
            DamageTextCount = 0;

            SpriteFont font = contentManager.Load<SpriteFont>(@"Fonts\LevelUpFont");
            LevelUpText = new SpriteText("Level Up!", font, Color.Blue);
            IsDrawingLevelUpText = false;
            LevelUpTextCount = 0;

            TextController.TileTextXSpacing = 7;
        }

        public static void ShowDamageText(Damage damage, Tile tile)
        {
            string text = "-" + damage.Value;
            Vector2 p = tile.Position;
            p.X += TileTextXSpacing;
            DamageText = new SpriteText(text, DamageFont, Color.Red, p);
            IsDrawingDamageText = true;
        }

        public static void ShowLevelUpText(Tile tile)
        {
            LevelUpText.SetPosition(tile.Position);
            IsDrawingLevelUpText = true;
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

            if (IsDrawingLevelUpText)
            {
                LevelUpTextCount++;
                LevelUpText.SetPosition(LevelUpText.Position - new Vector2(0, 1));
                if (LevelUpTextCount == 25)
                {
                    IsDrawingLevelUpText = false;
                    LevelUpTextCount = 0;
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (IsDrawingDamageText) DamageText.Draw(spriteBatch);
            if (IsDrawingLevelUpText) LevelUpText.Draw(spriteBatch);
        }

        #endregion
    }
}
