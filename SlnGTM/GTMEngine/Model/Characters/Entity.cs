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

        private static int AttackActionCost { get { return 10; } }

        protected Map Map { get; private set; }
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

        protected EnergyBar HPBar { get; set; }
        protected EnergyBar MPBar { get; set; }

        private Sprite Border { get; set; }

        //this is a unique identifier for each entity
        public int id { get; private set; }

        private Animation Animation { get; set; }
        private bool Animating { get; set; }

        public bool HasMoved { get; private set; }

        public Player MyPlayer { get; private set; }

        private int AttackActions { get; set; }

        #endregion

        #region Constructors

        public Entity(int ID, Map map, String name, Texture2D texture, Statistics stats, Player myPlayer) : base(name, texture, Vector2.Zero, new Size(50, 50))
        {
            this.id = ID;

            Map = map;
            Location = new MapLocation();
            InitialStats = stats;
            Stats = new Statistics(stats);

            Animating = false;
            Animation = new Animation(this, map, texture);

            MyPlayer = myPlayer;
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

            AttackActions = Stats.AttackSpeed;
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
            Console.WriteLine("Moving");
            Animation.SetAnimationPath(path);
            Animating = true;
            HasMoved = true;
        }

        public void AnimationEnded()
        {
            Animating = false;
            FlowController.CurrentGameState = GameFlowState.WaitingForPlayerAction;
            Position = Animation.Position;

            FlowController.CurrentGameState = GameFlowState.WaitingForPlayerAction;
        }

        public void TurnEnded()
        {
            HasMoved = false;
            AttackActions = Stats.AttackSpeed;
        }

        public Damage Attack(Entity e)
        {
            if (AttackActions >= AttackActionCost)
            {
                AttackActions -= AttackActionCost;
                Damage damage = new Damage(Stats.AttackDamage, DamageType.Physical, this);
                e.DealDamage(damage);
                return damage;
            }

            Console.WriteLine("Not enough attack actions this turn");
            return null;
        }

        public virtual void DealDamage(Damage dmg)
        {
            if (dmg.Type == DamageType.Physical || dmg.Type == DamageType.Composite)
            {
                dmg.Value -= Stats.Armor;
            }
            if (dmg.Type == DamageType.Magical || dmg.Type == DamageType.Composite)
            {
                dmg.Value -= Stats.MagicResist;
            }

            DealDamage(dmg.Value);
        }

        private void DealDamage(int value)
        {
            Stats.HP -= value;
            if (Stats.HP < 0) Stats.HP = 0;

            HPBar.Energy = Stats.HP;

            if (Stats.HP == 0) this.Die();
        }

        protected void Die()
        {
            Map.RemoveFromMap(this);
        }

        #endregion
    }
}
