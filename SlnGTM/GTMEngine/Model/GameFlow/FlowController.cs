using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GTMEngine.Model.Characters;

namespace GTMEngine.Model.GameFlow
{
    public class FlowController
    {
        #region Properties

        private Team RedTeam, BlueTeam;

        private Queue<Player> Turns { get; set; }
        public Player CurrentTurn { get; private set; }

        #endregion

        #region Constructors

        public FlowController(Team redTeam, Team blueTeam)
        {
            RedTeam = redTeam;
            BlueTeam = blueTeam;

            Turns = new Queue<Player>();

            OrganizeTurnQueue();

            if(Turns.Count > 0)
                CurrentTurn = Turns.Dequeue();
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
            CurrentTurn = Turns.Dequeue();
        }

        #endregion

    }
}
