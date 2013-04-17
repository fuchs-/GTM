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

        #endregion

        #region Properties

        public MapLocation Location 
        {
            get { return location; }

            set
            {
                location = value;

                SetNewPosition(new Vector2(location.X * 50, location.Y * 50));

            }
        }

        public Statistics InitialStats { get; protected set; }

        public Statistics Stats { get; protected set; }

        private EnergyBar HPBar { get; set; }
        private EnergyBar MPBar { get; set; }

        private Sprite Border { get; set; }

        //this is a unique identifier for each entity
        public int id { get; private set; }

        #endregion

        #region Constructors

        public Entity(int ID, String name, Texture2D texture, Statistics stats) : base(name, texture, Vector2.Zero, new Size(50, 50))
        {
            this.id = ID;

            Location = new MapLocation();
            InitialStats = stats;
            Stats = stats;
        }

        public Entity(int ID, String name, Texture2D texture) : base(name, texture, Vector2.Zero, new Size(50, 50))
        {
            this.id = ID;

            Location = new MapLocation();
            InitialStats = new Statistics();
        }

        #endregion

        #region Methods

        #region Flow Methods

        public void Initialize(Texture2D barBox, Texture2D hpBarTexture, Sprite border)
        {
            Vector2 barPosition = this.Position;
            Vector2 energyPosition;

            barPosition.Y += 45;

            energyPosition = barPosition + new Vector2(1);

            HPBar = new EnergyBar(InitialStats.HP, barBox, hpBarTexture, barPosition, energyPosition);

            Border = border;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Border != null) Border.Draw(spriteBatch);

            base.Draw(spriteBatch);

            HPBar.Draw(gameTime, spriteBatch);
        }

        #endregion

        public void SetNewPosition(Vector2 position)
        {
            Position = position;

            Vector2 barPosition = position;
            Vector2 borderPosition = position;

            barPosition.Y += 45;
            borderPosition -= new Vector2(1);

            if(HPBar != null) HPBar.Position = barPosition;
            if(Border != null) Border.Position = borderPosition;
        }

        #endregion
    }
}
