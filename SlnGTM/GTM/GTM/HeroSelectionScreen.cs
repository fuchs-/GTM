using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using GTM.Model.Characters;

namespace GTM
{
    public partial class HeroSelectionScreen : Form
    {
        XmlDocument heroListFile;

        public Team RedTeam { get; private set; }
        public Team BlueTeam { get; private set; }

        public HeroSelectionScreen()
        {
            InitializeComponent();

            RedTeam = new Team(TeamColor.Red);
            BlueTeam = new Team(TeamColor.Blue);
        }

        private void HeroSelectionScreen_Load(object sender, EventArgs e)
        {

            heroListFile = new XmlDocument();

            try
            {
                heroListFile.Load("HeroList.xml");
            }
            catch (XmlException ex)
            {
                MessageBox.Show("Xml Exception: " + ex.Message);
            }

            foreach (XmlNode node in heroListFile.SelectNodes("Heroes/Hero"))
            {
                cmbR1.Items.Add(node.InnerText);
                cmbR2.Items.Add(node.InnerText);
                cmbR3.Items.Add(node.InnerText);

                cmbB1.Items.Add(node.InnerText);
                cmbB2.Items.Add(node.InnerText);
                cmbB3.Items.Add(node.InnerText);
            }             
        }

        private void CheckAllValuesSelected(object sender, EventArgs e)
        {
            if ((cmbB1.Text != String.Empty) && (cmbB2.Text != String.Empty) && (cmbB3.Text != String.Empty) && (cmbR1.Text != String.Empty) && (cmbR2.Text != String.Empty) && (cmbR3.Text != String.Empty))
<<<<<<< HEAD
                this.Close();
=======
            {
                RedTeam.AddPlayer(new Player(Hero.LoadHero(cmbR1.Text), RedTeam));
                RedTeam.AddPlayer(new Player(Hero.LoadHero(cmbR2.Text), RedTeam));
                RedTeam.AddPlayer(new Player(Hero.LoadHero(cmbR3.Text), RedTeam));

                BlueTeam.AddPlayer(new Player(Hero.LoadHero(cmbB1.Text), BlueTeam));
                BlueTeam.AddPlayer(new Player(Hero.LoadHero(cmbB2.Text), BlueTeam));
                BlueTeam.AddPlayer(new Player(Hero.LoadHero(cmbB3.Text), BlueTeam));

                this.Close();
            }
>>>>>>> Continued the Hero Selection Screen
        }
    }
}