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

        public Team(TeamColor color)
        {
            Players = new List<Player>();
            Color = color;

            KD = new KDStatistics();
        }

        #endregion

        #region Methods

        #region Player management

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            
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
