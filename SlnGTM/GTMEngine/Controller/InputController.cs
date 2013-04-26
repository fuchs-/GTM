using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GTMEngine.Controller
{
    public static class InputController
    {
        #region Properties

        private static int LeftMouseCount = 0;
        private static int RightMouseCount = 0;

        #endregion

        #region Methods

        public static bool LeftMouseButtonClicked()
        {
            bool b = Mouse.GetState().LeftButton.Equals(ButtonState.Pressed);

            if (b)
            {
                if (LeftMouseCount > 0)
                    b = false;
                else
                    LeftMouseCount++;
            }
            else
                LeftMouseCount = 0;

            return b;
        }

        public static bool RightMouseButtonClicked()
        {
            bool b = Mouse.GetState().RightButton.Equals(ButtonState.Pressed);

            if (b)
            {
                if (RightMouseCount > 0)
                    b = false;
                else
                    RightMouseCount++;
            }
            else
                RightMouseCount = 0;

            return b;
        }

        public static bool IsMouseInside(Rectangle rect)
        {
            return rect.Contains(GetMousePosition());
        }

        public static Point GetMousePosition()
        { 
            MouseState s = Mouse.GetState();
            return new Point(s.X, s.Y);
        }

        #endregion
    }
}
