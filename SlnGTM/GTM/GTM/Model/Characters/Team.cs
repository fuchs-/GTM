using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTM.Model.Characters
{
    public enum TeamColor { Blue, Red }

    public class Team
    {
        #region Properties

        private List<Player> Players { get; set; }

        public TeamColor Color { get; private set; }

        public KDStatistics KD { get; private set; }

        #endregion

        #region Constructors

        public Team(TeamColor color, List<Player> players)
        {
            Players = players;
            Color = color;

            KD = new KDStatistics();
        }

        public Team(TeamColor color) : this(color, new List<Player>()) { }

        #endregion

        #region Methods

        #region Player management

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            
        }

        public List<Hero> GetHeroes()
        {
            List<Hero> heroes = new List<Hero>();

            foreach (Player p in Players)
            {
                heroes.Add(p.CurrentHero);
            }

            return heroes;
        }

        //Used for organizing the turn queue (FlowController)
        public Queue<Player> GetPlayerQueue()
        {
            Queue<Player> ret = new Queue<Player>();

            foreach (Player p in Players)
            {
                ret.Enqueue(p);
            }
            
            return ret;
        }

        #endregion

        #endregion
    }
}
