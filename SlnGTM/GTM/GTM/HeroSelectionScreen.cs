using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using GTMEngine.Model.Characters;

namespace GTM
{
    public partial class HeroSelectionScreen : Form
    {

        public Team RedTeam { get; private set; }
        public Team BlueTeam { get; private set; }

        public HeroSelectionScreen()
        {
            InitializeComponent();

            RedTeam = new Team(TeamColor.Red);
            BlueTeam = new Team(TeamColor.Blue);
        }

        public void LoadHeroNames(ContentManager contentManager)
        {
            List<String> heroes = contentManager.Load<List<String>>(@"Heroes\HeroList");

            foreach (String s in heroes)
            {
                cmbR1.Items.Add(s);
                cmbR2.Items.Add(s);
                cmbR3.Items.Add(s);

                cmbB1.Items.Add(s);
                cmbB2.Items.Add(s);
                cmbB3.Items.Add(s);
            }
        }

        private void CheckAllValuesSelected(object sender, EventArgs e)
        {
            if ((cmbB1.Text != String.Empty) && (cmbB2.Text != String.Empty) && (cmbB3.Text != String.Empty) && (cmbR1.Text != String.Empty) && (cmbR2.Text != String.Empty) && (cmbR3.Text != String.Empty))
            {
                Player p;

                p = new Player(lblR1.Text, RedTeam);
                p.SetCurrentHero(EntityLoader.LoadHero(cmbR1.Text, TeamColor.Red, p));
                RedTeam.AddPlayer(p);

                p = new Player(lblR2.Text, RedTeam);
                p.SetCurrentHero(EntityLoader.LoadHero(cmbR2.Text, TeamColor.Red, p));
                RedTeam.AddPlayer(p);

                p = new Player(lblR3.Text, RedTeam);
                p.SetCurrentHero(EntityLoader.LoadHero(cmbR3.Text, TeamColor.Red, p));
                RedTeam.AddPlayer(p);


                p = new Player(lblB1.Text, BlueTeam);
                p.SetCurrentHero(EntityLoader.LoadHero(cmbB1.Text, TeamColor.Red, p));
                BlueTeam.AddPlayer(p);

                p = new Player(lblB2.Text, BlueTeam);
                p.SetCurrentHero(EntityLoader.LoadHero(cmbB2.Text, TeamColor.Red, p));
                BlueTeam.AddPlayer(p);

                p = new Player(lblB3.Text, BlueTeam);
                p.SetCurrentHero(EntityLoader.LoadHero(cmbB3.Text, TeamColor.Red, p));
                BlueTeam.AddPlayer(p);

                this.Close();
            }
        }

        private void btnIchigo_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name == "ComboBox")
                {
                    ComboBox cmb = (ComboBox)c;
                    cmb.SelectedIndex = 0;
                }
            }
        }

        private void btnByakuya_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name == "ComboBox")
                {
                    ComboBox cmb = (ComboBox)c;
                    cmb.SelectedIndex = 1;
                }
            }
        }

        private void btnHalf_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name == "ComboBox")
                {
                    ComboBox cmb = (ComboBox)c;
                    if (cmb.Name.StartsWith("cmbR"))
                        cmb.SelectedIndex = 0;
                    else
                        cmb.SelectedIndex = 1;
                }
            }
        }
    }
}