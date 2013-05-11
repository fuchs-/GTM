using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTMEngine.Model.Characters
{
    public enum TeamColor { Blue, Red }

    public class Team
    {
        #region Properties

        private List<Player> Players { get; set; }

        public TeamColor Color { get; private set; }

        public KDStatistics KD { get; private set; }

        private List<MapLocation> SpawningPoints { get; set; }

        #endregion

        #region Constructors

        public Team(TeamColor color, List<Player> players)
        {
            Players = players;
            Color = color;

            KD = new KDStatistics();
            
            SpawningPoints = new List<MapLocation>();

            int x = 0;

            if (Color == TeamColor.Blue)
            {
                x = Map.X - 1;
            }

            for (int y = 0; y < Map.Y; y++)
            {
                SpawningPoints.Add(new MapLocation(x, y));
            }
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

        public MapLocation GetSpawningPoint()
        {
            MapLocation ret;
            int i;

            Random r = new Random();
            i = r.Next();

            i = i % SpawningPoints.Count;

            ret = SpawningPoints[i];

            return ret;
        }

        #endregion

        #endregion
    }
}
