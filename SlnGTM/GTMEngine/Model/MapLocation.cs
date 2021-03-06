﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTMEngine.Model
{
    public class MapLocation
    {
        #region Properties

        public int X { get; set; }

        public int Y { get; set; }

        #endregion

        #region Constructors

        public MapLocation(int x, int y)
        {
            X = x;
            Y = y;
        }

        public MapLocation() : this(0,0) { }

        #endregion

        #region Methods

        //public void CenterLocation(Map map) { }

        public void WalkX(int steps)
        {
            X += steps;
        }

        public void WalkX()
        {
            WalkX(1);
        }

        public void WalkY(int steps)
        {
            Y += steps;
        }

        public void WalkY()
        {
            WalkY(1);
        }

        public override string ToString()
        {
            return "(" + X + ";" + Y + ")";
        }

        public bool Equals(MapLocation l)
        {
            return X == l.X && Y == l.Y;
        }

        #endregion

        #region Operators

        public static bool operator ==(MapLocation l1, MapLocation l2) 
        {
            return (l1.X == l2.X) && (l1.Y == l2.Y);
        }

        public static bool operator !=(MapLocation l1, MapLocation l2)
        {
            return (l1.X != l2.X) || (l1.Y != l2.Y);
        }

        #endregion
    }
}
