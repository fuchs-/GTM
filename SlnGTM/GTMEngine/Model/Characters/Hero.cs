using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using BXEL.Graphics;

using GTMEngine.UI;
using GTMEngine.Controller.GameFlow;

namespace GTMEngine.Model.Characters
{
    public class Hero : Entity, ITurnChangeListener
    {
        #region Properties

        public static Dictionary<int, int> LevelUpExperiences { get; private set; }

        private Statistics LevelUpStats { get; set; }
        public KDStatistics KDStats { get; private set; }

        public int Level { get; private set; }
        public int Experience { get; private set; }
        public int ExperienceToNextLevel { get; private set; }

        private Texture2D CharImage { get; set; }

        public HUDDisplay MyHUDDisplay { get; private set; }

        public bool IsDead { get; private set; }
        public int RemainingDeadTurns { get; private set; }

        #endregion

        #region Constructors

        public Hero(int ID, Map map, string name, Texture2D texture, Statistics baseStats, Player myPlayer) : base(ID, map, name, texture, baseStats, myPlayer)
        {
            LevelUpStats = new Statistics();
            KDStats = new KDStatistics();
            Level = 1;
            Experience = 0;
            ExperienceToNextLevel = Hero.LevelUpExperiences[1];

            CharImage = texture; //this is provisory, there will be a different texture for the char image

            HUDDisplayObject hdo = new HUDDisplayObject(HUDDisplayObjectType.CharImage, CharImage);

            MyHUDDisplay = new HUDDisplay();
            MyHUDDisplay.AddObject(hdo);

            MyHUDDisplay.InitializeEnergyBars(this.InitialStats.HP, this.InitialStats.MP);

            IsDead = false;
            RemainingDeadTurns = 0;
        }

        #endregion

        #region Methods

        #region Flow Methods

        public static void LoadContent(ContentManager contentManager)
        {
            LevelUpExperiences = contentManager.Load<Dictionary<int, int>>(@"Heroes\LevelUpExperiences");
        }

        #endregion

        public void GiveExperience(int exp)
        {
            Experience += exp;

            if (Experience >= ExperienceToNextLevel)
            {
                Experience = Experience - ExperienceToNextLevel;
                this.LevelUp();
            }
        }

        private void LevelUp()
        {
            Level++;

            Stats += LevelUpStats;
            InitialStats += LevelUpStats;
            ExperienceToNextLevel = Hero.LevelUpExperiences[Level];

            Tile t = Map.GetTileAtLocation(Location);
            TextController.ShowLevelUpText(t);

            //probably some ability level up logic goes here
        }

        public override void DealDamage(Damage damage)
        {
            base.DealDamage(damage);
            MyHUDDisplay.HPBar.Energy = Stats.HP;

            if (Stats.HP == 0)
            {
                this.Die(damage.Source);               
            }
        }

        public void TurnChanged()
        {
            if (IsDead)
            {
                if (--RemainingDeadTurns == 0) Revive();
            }
        }

        private void Die(Entity e)
        {
            IsDead = true;
            KDStats.Died();
            MyPlayer.CurrentTeam.KD.Died();

            Hero h = e.MyPlayer.CurrentHero; //If the source its not the hero itself

            h.KDStats.Killed();
            h.MyPlayer.CurrentTeam.KD.Killed();

            h.GiveExperience(1);

            RemainingDeadTurns = KDStats.Deaths + 1;
        }

        private void Revive()
        {
            if (!Map.AddToMap(this))
            {
                IsDead = true;
                RemainingDeadTurns = 1;

                return;
            }

            Console.WriteLine(Name + "Has revived");

            IsDead = false;
            Stats.HP = InitialStats.HP;
            HPBar.Energy = Stats.HP;
            MyHUDDisplay.HPBar.Energy = Stats.HP;
        }

        #endregion
    }
}
