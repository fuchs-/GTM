using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using BXEL.Graphics;

namespace GTM.Model.Characters
{
    public class Entity : Sprite
    {
        #region Attributes

        private MapLocation location;

        private EnergyBar HPBar { get; set; }
        private EnergyBar MPBar { get; set; }

        #endregion

        #region Properties

        public MapLocation Location 
        {
            get { return location; }

            set
            {
                location = value;

                this.Position = new Vector2(location.X * 50, location.Y * 50);

            }
        }

        public Statistics InitialStats { get; protected set; }

        public Statistics Stats { get; protected set; }

        #endregion

        #region Constructors

        public Entity(String name, Texture2D texture, Statistics stats) : base(name, texture, Vector2.Zero, new Size(50, 50))
        {
            Location = new MapLocation();
            InitialStats = stats;
            Stats = stats;
        }

        public Entity(String name, Texture2D texture) : base(name, texture, Vector2.Zero, new Size(50, 50))
        {
            Location = new MapLocation();
            InitialStats = new Statistics();
        }

        #endregion

        #region Methods

        #region Flow Methods

        public void LoadContent(ContentManager contentManager)
        {
            Texture2D barBox = contentManager.Load<Texture2D>(@"Images\EnergyBarBox");
            Texture2D hpBarTexture = contentManager.Load<Texture2D>(@"Images\HPBar");

            Vector2 barPosition = this.Position;
            Vector2 energyPosition;

            barPosition.Y += 45;

            energyPosition = barPosition + new Vector2(1);

            HPBar = new EnergyBar(InitialStats.HP, barBox, hpBarTexture, barPosition, energyPosition);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            HPBar.Draw(gameTime, spriteBatch);
        }

        #endregion

        public void SetNewPosition(Vector2 position)
        {
            Position = position;

            Vector2 barPosition = position;
            barPosition.Y += 45;

            HPBar.Position = barPosition;
        }

        #endregion
    }
}
