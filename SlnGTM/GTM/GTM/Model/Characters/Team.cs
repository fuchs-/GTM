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

        #endregion

        #region Constructors

        public Team(TeamColor color)
        {
            Players = new List<Player>();
            Color = color;
        }

        #endregion

        #region Methods

        #region Hero management

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            
        }

        #endregion

        #endregion
    }
}
