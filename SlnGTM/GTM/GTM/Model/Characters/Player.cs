﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTM.Model.Characters
{
    public class Player
    {
        #region Properties

        public Hero CurrentHero { get; private set; }
        
        public Team CurrentTeam { get; private set; }

        public KDStatistics KD { get; private set; }

        #endregion

        #region Constructors

        public Player(Hero hero, Team team)
        {
            CurrentHero = hero;
            CurrentTeam = team;

            KD = new KDStatistics();
        }

        #endregion

        #region Methods

        public void AddedToTeam(Team team)
        {
            CurrentTeam = team;
        }

        #endregion
    }
}
