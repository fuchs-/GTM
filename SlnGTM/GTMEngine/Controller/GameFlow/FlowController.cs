using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using GTMEngine.Model;

namespace GTMEngine.Controller.GameFlow
{
    public enum GameFlowState 
    { 
        WaitingForPlayerAction
    }
    //This class gives me goosebumps...
    //Good luck bra
    public class FlowController
    {
        #region Properties

        public static GameFlowState CurrentGameState { get; private set; }

        #endregion

        #region Constructors

        public FlowController()
        {
            CurrentGameState = GameFlowState.WaitingForPlayerAction;
        }

        #endregion


        #region Methods

        #region Flow Methods

        public void Update(GameTime gameTime)
        {
            switch (CurrentGameState)
            { 
                case GameFlowState.WaitingForPlayerAction:
                    
                    break;
            }
        }

        #endregion

        #endregion
    }
}
