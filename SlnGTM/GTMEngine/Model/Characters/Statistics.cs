using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GTMEngine.Model.Characters
{
    public class Statistics
    {   
        #region Properties

        public int HP { get; set; }
        public int HPRegen { get; set; }

        public int MP { get; set; }
        public int MPRegen { get; set; }

        public int AttackDamage { get; set; }
        public int AttackSpeed { get; set; }
        public int MovementSpeed { get; set; }

        #endregion

        #region Constructors

        public Statistics(int hp, int hpRegen, int mp, int mpRegen, int atkDmg, int atkSpd, int movSpd)
        {
            HP = hp;
            HPRegen = hpRegen;
            MP = mp;
            MPRegen = mpRegen;

            AttackDamage = atkDmg;
            AttackSpeed = atkSpd;
            MovementSpeed = movSpd;
        }

        public Statistics() : this(0, 0, 0, 0, 0, 0, 0) { }

        #endregion
    }
}
