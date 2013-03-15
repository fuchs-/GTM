using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace GTM.Model.Characters
{
    public class KDStatistics
    {
        #region Properties

        public int Kills { get; private set; }
        public int Deaths { get; private set; }

        public int ConsecutiveKills { get; private set; }
        public int MultiKill { get; private set; }

        private int MultiKillTurnLimit;
        private int TurnCount;

        #endregion

        #region Constructors

        public KDStatistics(int kills, int deaths, int consecutiveKills, int multiKillTurnLimit)
        {
            Kills = kills;
            Deaths = deaths;
            ConsecutiveKills = consecutiveKills;
            MultiKill = 0;
            MultiKillTurnLimit = multiKillTurnLimit;
            TurnCount = 0;
        }

        public KDStatistics(int multiKillTurnLimit) : this(0, 0, 0, multiKillTurnLimit) { }

        public KDStatistics() : this(3) { }

        #endregion

        #region Methods

        #region FlowMethods

        //This will have to update the turn count
        //Update()

        #endregion

        public void Killed()
        {
            Kills++;

            TurnCount = MultiKillTurnLimit;

            ConsecutiveKills++;
            MultiKill++;
        }

        public void Died()
        {
            Deaths++;

            TurnCount = 0;
            ConsecutiveKills = 0;
            MultiKill = 0;
        }

        public override string ToString()
        {
            return Kills + "/" + Deaths;
        }

        #endregion
    }
}
