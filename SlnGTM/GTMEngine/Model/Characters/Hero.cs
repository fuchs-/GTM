using System;
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

        #endregion

        #region Constructors

        public Hero(int ID, string name, Texture2D texture, Statistics baseStats) : base(ID, name, texture, baseStats)
        {
            LevelUpStats = new Statistics();
        }

        public Hero(int ID, string name, Texture2D texture) : base(ID, name, texture)
        {
            LevelUpStats = new Statistics();
        }

        #endregion

        #region Methods

        #region Flow Methods

        public static void LoadContent(ContentManager contentManager)
        {
            LevelUpExperiences = contentManager.Load<Dictionary<int, int>>(@"Heroes\LevelUpExperiences");
        }

        #endregion

        #endregion
    }
}
