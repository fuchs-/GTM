﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using BXEL.Graphics;

namespace GTMEngine.Model.Characters
{
    public class Hero : Entity
    {
        #region Properties

        public static Dictionary<int, int> LevelUpExperiences { get; private set; }

        private Statistics LevelUpStats { get; set; }

        public int Level { get; private set; }
        public int Experience { get; private set; }
        public int ExperienceToNextLevel { get; private set; }

        public Texture2D CharImage { get; private set; }

        #endregion

        #region Constructors

        public Hero(int ID, string name, Texture2D texture, Statistics baseStats) : base(ID, name, texture, baseStats)
        {
            LevelUpStats = new Statistics();
            Level = 1;
            Experience = 0;
            ExperienceToNextLevel = Hero.LevelUpExperiences[1];

            CharImage = texture; //this is provisory, there will be a different texture for the char image
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
            ExperienceToNextLevel = Hero.LevelUpExperiences[Level];

            //probably some ability level up logic goes here
        }

        #endregion
    }
}