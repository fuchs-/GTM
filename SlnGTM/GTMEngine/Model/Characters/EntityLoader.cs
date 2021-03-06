﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using BXEL.Graphics;

namespace GTMEngine.Model.Characters
{
    public static class EntityLoader
    {
        #region Properties

        private static int CurrentID { get; set; }

        private static ContentManager ContentManager { get; set; }

        private static Map Map { get; set; }

        public static bool IsReady { get; private set; }

        #region Textures

        private static Texture2D EnergyBarBox { get; set; }
        private static Texture2D HPBar { get; set; }
        private static Texture2D MPBar { get; set; }

        private static Texture2D RedEntityBorder { get; set; }
        private static Texture2D BlueEntityBorder { get; set; }

        #endregion

        #endregion

        #region Methods

        public static void Initialize(ContentManager contentManager, Map map)
        {
            if (contentManager == null) return;

            CurrentID = 0;

            ContentManager = contentManager;
            Map = map;

            //Loading Textures
            EnergyBarBox = ContentManager.Load<Texture2D>(@"Images\Entities\EnergyBarBox");
            HPBar = ContentManager.Load<Texture2D>(@"Images\Entities\HPBar");
            MPBar = ContentManager.Load<Texture2D>(@"Images\Entities\MPBar");

            RedEntityBorder = ContentManager.Load<Texture2D>(@"Images\Entities\RedBorder");
            BlueEntityBorder = ContentManager.Load<Texture2D>(@"Images\Entities\BlueBorder");

            IsReady = true;
        }

        public static Hero LoadHero(string heroName, TeamColor color, Player player)
        {
            if (!IsReady) return null;
            
            Hero ret = null;

            Texture2D charTexture = ContentManager.Load<Texture2D>(@"Heroes\" + heroName + @"\char");

            ret = new Hero(CurrentID++, Map, heroName, charTexture, ContentManager.Load<Statistics>(@"Heroes\" + heroName + @"\Statistics"), player);

            ret.Initialize(EnergyBarBox, HPBar, GetBorderSprite(color));

            return ret;
        }

        private static Sprite GetBorderSprite(TeamColor color)
        {
            Sprite borderSprite;

            if (color == TeamColor.Red)
                borderSprite = new Sprite("RedBorder", RedEntityBorder);
            else
                borderSprite = new Sprite("BlueBorder", BlueEntityBorder);

            return borderSprite;
        }

        #endregion
    }
}
