using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using BXEL.Graphics;
using BXEL.DataStructures;

using GTMEngine.Controller.GameFlow;

namespace GTMEngine.Model.Characters
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

        protected Statistics InitialStats { get; set; }

        public Statistics Stats { get; protected set; }

        private EnergyBar HPBar { get; set; }
        private EnergyBar MPBar { get; set; }

        private Sprite Border { get; set; }

        //this is a unique identifier for each entity
        public int id { get; private set; }

        private Animation Animation { get; set; }
        private bool Animating { get; set; }

        public bool HasMoved { get; private set; }

        #endregion

        #region Constructors

        public Entity(int ID, Map map, String name, Texture2D texture, Statistics stats) : base(name, texture, Vector2.Zero, new Size(50, 50))
        {
            this.id = ID;

            Location = new MapLocation();
            InitialStats = stats;
            Stats = stats;

            Animating = false;
            Animation = new Animation(this, map, texture);
        }

        public Entity(int ID, Map map, String name, Texture2D texture) : base(name, texture, Vector2.Zero, new Size(50, 50))
        {
            this.id = ID;

            Location = new MapLocation();
            InitialStats = new Statistics();

            Animating = false;
            Animation = new Animation(this, map, texture);
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

        public override void Update(GameTime gameTime)
        {
            UpdateBarAndBorder();
            Animation.Update(gameTime);

            base.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Border != null) Border.Draw(spriteBatch);

            if (Animating) Animation.Draw(spriteBatch);
            else base.Draw(spriteBatch);

            HPBar.Draw(spriteBatch);
        }

        #endregion

        public void SetNewPosition(Vector2 position)
        {
            Position = position;

            UpdateBarAndBorder();
        }

        public void UpdateBarAndBorder()
        {
            Vector2 barPosition = Position;
            Vector2 borderPosition = Position;

            if (Animating)
            {
                barPosition = Animation.Position;
                borderPosition = Animation.Position;
            }

            barPosition.Y += 45;
            borderPosition -= new Vector2(1);

            if (HPBar != null) HPBar.SetPosition(barPosition);
            if (Border != null) Border.SetPosition(borderPosition);
        }
        
        public bool Equals(Entity e)
        {
            return this.id == e.id;
        }

        public void Move(Path path)
        {
            if (!HasMoved)
            {
                Console.WriteLine("Moving");
                Animation.SetAnimationPath(path);
                Animating = true;
                HasMoved = true;
            }
            else
            {
                Console.WriteLine("This entity already moved on this turn");
            }
        }

        public void AnimationEnded()
        {
            Animating = false;
            FlowController.CurrentGameState = GameFlowState.WaitingForPlayerAction;
            Position = Animation.Position;
        }

        public void TurnEnded()
        {
            HasMoved = false;
        }

        #endregion
    }
}
