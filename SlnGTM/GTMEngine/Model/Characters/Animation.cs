using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BXEL.Graphics;
using BXEL.DataStructures;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GTMEngine.Model.Characters
{
    enum AnimationState
    { 
        WaitingForPath,
        Playing
    }

    public class Animation : Sprite
    {
        #region Properties

        private Path Path { get; set; }
        private Map Map { get; set; }
        private Entity Entity { get; set; }

        private Vector2 CurrentUpdate { get; set; }
        private Vector2 CurrentGoal { get; set; }

        private AnimationState CurrentState { get; set; }

        #endregion

        #region Constructors

        public Animation(Entity entity, Map map, Texture2D texture) : base("Animation", texture, entity.Rectangle)
        {
            Entity = entity;
            Map = map;

            CurrentState = AnimationState.WaitingForPath;
        }
        
        #endregion

        #region Methods

        public void SetAnimationPath(Path path)
        {
            Path = path;
            TileVertice v = (TileVertice) path.NextVertice;
            Position = Map.GetScreenPosition(v.Location);

            if (SetNewGoal()) this.CurrentState = AnimationState.Playing;
        }

        public bool SetNewGoal()
        {
            if (Path.IsOver()) return false;

            TileVertice v = (TileVertice) Path.NextVertice;

            CurrentGoal = Map.GetScreenPosition(v.Location);

            Vector2 aux = CurrentGoal - Position;

            
            if (aux.X == 0) //Vertical Movement
            {
                if (aux.Y < 0) //Up
                {
                    CurrentUpdate = new Vector2(0, -1);
                }
                else //Down
                {
                    CurrentUpdate = new Vector2(0, 1);
                }
            }
            else //Horrizontal movement
            {
                if (aux.X < 0) //Left
                {
                    CurrentUpdate = new Vector2(-1, 0);
                }
                else //Right
                {
                    CurrentUpdate = new Vector2(1, 0);
                }
            }

            return true;
        }

        public override void Update(GameTime gameTime)
        {
            if (CurrentState == AnimationState.Playing)
            {
                Position += CurrentUpdate;

                if (Position.Equals(CurrentGoal))
                {
                    if (!SetNewGoal()) EndAnimation();
                }
            }
        }

        public void EndAnimation()
        {
            this.Path = null;
            CurrentState = AnimationState.WaitingForPath;
            Entity.AnimationEnded();
            Point p = new Point((int)Position.X, (int)Position.Y);
            Entity.Location = Map.GetTileAtPoint(p).Location;
        }

        #endregion
    }
}
