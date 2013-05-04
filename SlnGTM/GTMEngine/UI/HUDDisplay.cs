using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BXEL.Graphics.UI;
using BXEL.Graphics;

using Microsoft.Xna.Framework;

using GTMEngine.Controller;

namespace GTMEngine.UI
{
    public class HUDDisplay : UIPanel , UIButtonListener
    {
        #region Properties 

        public EnergyBar HPBar { get; private set; }
        public EnergyBar MPBar { get; private set; }

        public UIButton NextTurnButton { get; private set; }

        #endregion

        #region Constructors

        public HUDDisplay() : base("HUDDisplay", null, HUD.HUDPosition, HUD.HUDSize, Color.White) 
        {
            NextTurnButton = new UIButton("Next Turn", new Sprite("Normal", HUD.NextTurnButtonTexture, HUD.NextTurnButtonPosition));
            AddObject(NextTurnButton);

            NextTurnButton.AddListener(this);
        }

        #endregion

        #region Methods

        #region Flow Methods

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Rectangle r = this.NextTurnButton.Rectangle;

            if (InputController.IsMouseInside(r) && InputController.LeftMouseButtonClicked()) HUD.Map.TurnController.NextTurn();

            /*
            if (NextTurnButton.IsPressed)
            {
                HUD.Map.TurnController.NextTurn();
            }
             */
        }

        #endregion

        public void InitializeEnergyBars(int maxHP, int maxMP)
        {
            HPBar = new EnergyBar(maxHP, HUD.EnergyBarBox, HUD.HPBarTexture, HUD.HPBarPosition, HUD.HPBarPosition + new Vector2(3, 3));
            MPBar = new EnergyBar(maxMP, HUD.EnergyBarBox, HUD.MPBarTexture, HUD.MPBarPosition, HUD.MPBarPosition + new Vector2(3));

            Sprite s = new Sprite("s", HUD.EnergyBarBox, new Vector2(200, 10));

            this.AddObject(HPBar);
            this.AddObject(MPBar);
        }

        public void ButtonPressed(string buttonName)
        {
            if (buttonName == "Next Turn") Console.WriteLine("Butao pressionado");
        }

        #endregion
    }
}
