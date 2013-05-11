using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GTMEngine.Model;
using GTMEngine.Model.Characters;
using GTMEngine.UI;

namespace GTMEngine.Controller.GameFlow
{
    public class TurnController
    {
        #region Properties

        private Map Map;
        private HUD HUD;
        private Team RedTeam, BlueTeam;

        private Queue<Player> Turns { get; set; }
        public Player CurrentTurn { get; private set; }

        private List<ITurnChangeListener> TurnChangeListeners { get; set; }

        #endregion

        #region Constructors

        public TurnController(Map map, HUD hud, Team redTeam, Team blueTeam)
        {
            Map = map;
            HUD = hud;
            RedTeam = redTeam;
            BlueTeam = blueTeam;

            Turns = new Queue<Player>();

            TurnChangeListeners = new List<ITurnChangeListener>();

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

            Player p;

            while (red.Count > 0 && blue.Count > 0)
            {
                p = red.Dequeue();
                Turns.Enqueue(p);
                TurnChangeListeners.Add(p.CurrentHero);

                p = blue.Dequeue();
                Turns.Enqueue(p);
                TurnChangeListeners.Add(p.CurrentHero);
            }
        }

        public void NextTurn()
        {

            do
            {
                foreach (ITurnChangeListener l in TurnChangeListeners) l.TurnChanged();

                Turns.Enqueue(CurrentTurn);
                Map.TurnEnded(CurrentTurn.CurrentHero);
                CurrentTurn.CurrentHero.TurnEnded();
                CurrentTurn = Turns.Dequeue();

            } while (CurrentTurn.CurrentHero.IsDead);
            
            
            Map.TurnStarted();

            HUD.ChangeHUDDisplay(CurrentTurn.CurrentHero.MyHUDDisplay);
        }

        #endregion

    }
}
