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
        public int AttackRange { get; set; }
        public int MovementSpeed { get; set; }

        public int Armor { get; set; }
        public int MagicResist { get; set; }

        #endregion

        #region Constructors

        public Statistics(int hp, int hpRegen, int mp, int mpRegen, int atkDmg, int atkSpd, int atkRange, int movSpd, int armor, int magicResist)
        {
            HP = hp;
            HPRegen = hpRegen;
            MP = mp;
            MPRegen = mpRegen;

            AttackDamage = atkDmg;
            AttackSpeed = atkSpd;
            AttackRange = atkRange;
            MovementSpeed = movSpd;

            Armor = armor;
            MagicResist = magicResist;
        }

        public Statistics(Statistics s) : this(s.HP, s.HPRegen, s.MP, s.MPRegen, s.AttackDamage, s.AttackSpeed, s.AttackRange, s.MovementSpeed, s.Armor, s.MagicResist) { }

        public Statistics() : this(0, 0, 0, 0, 0, 0, 0, 0, 0, 0) { }

        #endregion

        #region Operators

        public static Statistics operator +(Statistics s1, Statistics s2)
        {
            Statistics ret = new Statistics(s1);

            ret.HP += s2.HP;
            ret.HPRegen += s2.HPRegen;
            ret.MP += s2.MP;
            ret.MPRegen += s2.MPRegen;

            ret.AttackDamage += s2.AttackDamage;
            ret.AttackSpeed += s2.AttackSpeed;
            ret.MovementSpeed += s2.MovementSpeed;

            return ret;
        }

        public static Statistics operator -(Statistics s1, Statistics s2)
        {
            Statistics ret = new Statistics(s1);

            ret.HP -= s2.HP;
            ret.HPRegen -= s2.HPRegen;
            ret.MP -= s2.MP;
            ret.MPRegen -= s2.MPRegen;

            ret.AttackDamage -= s2.AttackDamage;
            ret.AttackSpeed -= s2.AttackSpeed;
            ret.MovementSpeed -= s2.MovementSpeed;

            return ret;
        }

        #endregion
    }
}
