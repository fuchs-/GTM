using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BXEL.Graphics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GTMEngine.UI
{
    public enum HUDDisplayObjectType
    { 
        CharImage,
        HPBar,
        MPBar,
        Ability1,
        Ability2,
        Ability3,
        Ability4
    }

    public class HUDDisplayObject : Sprite
    {
        #region Properties

        public HUDDisplayObjectType ObjectType { get; private set; }

        #endregion

        #region Constructors

        public HUDDisplayObject(HUDDisplayObjectType type, Texture2D texture) : base(type.ToString(), texture) 
        { 
            switch (type)
            { 
                case HUDDisplayObjectType.CharImage:
                    this.Position = new Vector2(10, 10);
                    this.Size = new Size(150, 150);
                    break;
            }
        }

        #endregion
    }
}
