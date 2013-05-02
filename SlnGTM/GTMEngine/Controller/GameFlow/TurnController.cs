using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GTMEngine.Model;
using GTMEngine.Model.Characters;

namespace GTMEngine.Controller.GameFlow
{
    public class TurnController
    {
        #region Properties

        private Map Map;
        private Team RedTeam, BlueTeam;

        private Queue<Player> Turns { get; set; }
        public Player CurrentTurn { get; private set; }

        #endregion

        #region Constructors

        public TurnController(Map map, Team redTeam, Team blueTeam)
        {
            Map = map;
            RedTeam = redTeam;
            BlueTeam = blueTeam;

            Turns = new Queue<Player>();

            OrganizeTurnQueue();

            if (Turns.Count > 0)
            {
                CurrentTurn = Turns.Dequeue();
            }
        }

        #endregion

        #region Methods

        private void OrganizeTurnQueue()
        {
            if (RedTeam == null || BlueTeam == null)
                return;

            Queue<Player> red, blue;

            red = RedTeam.GetPlayerQueue();
            blue = BlueTeam.GetPlayerQueue();

            Turns.Clear();

            while (red.Count > 0 && blue.Count > 0)
            {
                Turns.Enqueue(red.Dequeue());
                Turns.Enqueue(blue.Dequeue());
            }
        }

        public void NextTurn()
        {
            Turns.Enqueue(CurrentTurn);
            Map.TurnEnded(CurrentTurn.CurrentHero);
            CurrentTurn = Turns.Dequeue();
            Map.TurnStarted();
        }

        #endregion

    }
}
