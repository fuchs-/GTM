using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace GTM.Model.Characters
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

        public Statistics(XmlDocument file)
        {
            XmlNode node;

            node = file.SelectSingleNode("Statistics/HP");
            HP = Convert.ToInt32(node.InnerText);
            node = file.SelectSingleNode("Statistics/HPRegen");
            HPRegen = Convert.ToInt32(node.InnerText);

            node = file.SelectSingleNode("Statistics/MP");
            MP = Convert.ToInt32(node.InnerText);
            node = file.SelectSingleNode("Statistics/MPRegen");
            MPRegen = Convert.ToInt32(node.InnerText);

            node = file.SelectSingleNode("Statistics/AD");
            AttackDamage = Convert.ToInt32(node.InnerText);

            node = file.SelectSingleNode("Statistics/AtkSpeed");
            AttackSpeed = Convert.ToInt32(node.InnerText);

            node = file.SelectSingleNode("Statistics/MovSpeed");
            MovementSpeed = Convert.ToInt32(node.InnerText);
        }

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
