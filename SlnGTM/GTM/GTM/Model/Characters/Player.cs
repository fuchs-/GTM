using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTM.Model.Characters
{
    public class Player
    {
        #region Properties

        public string Name { get; private set; }

        public Hero CurrentHero { get; private set; }
        
        public Team CurrentTeam { get; private set; }

        public KDStatistics KD { get; private set; }

        private List<int> EntitiesUnderControl { get; set; }

        #endregion

        #region Constructors

        public Player(string name, Hero hero, Team team)
        {
            Name = name;
            CurrentHero = hero;
            CurrentTeam = team;

            KD = new KDStatistics();
            EntitiesUnderControl = new List<int>();

            GiveControl(CurrentHero);
        }

        #endregion

        #region Methods

        public void AddedToTeam(Team team)
        {
            CurrentTeam = team;
        }

        public void GiveControl(Entity e)
        {
            EntitiesUnderControl.Add(e.id);
        }

        public bool HasControl(Entity e)
        {
            return EntitiesUnderControl.Contains(e.id);
        }

        public void RemoveControl(Entity e)
        {
            EntitiesUnderControl.Remove(e.id);
        }

        #endregion
    }
}
