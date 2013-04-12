﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;

namespace GTM.Model.Characters
{
    public static class HeroLoader
    {
        #region Properties

        private static ContentManager ContentManager { get; set; }

        public static bool IsReady { get; private set; }

        #endregion

        #region Methods

        public static void Initialize(ContentManager contentManager)
        {
            ContentManager = contentManager;

            if (ContentManager != null) IsReady = true;
        }

        public static Hero LoadHero(string heroName)
        {
            if (!IsReady) return null;

            
            Hero ret = null;

            //insert loading code here

            return ret;
        }

        #endregion
    }
}