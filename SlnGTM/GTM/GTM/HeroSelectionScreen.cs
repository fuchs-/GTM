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

namespace GTM
{
    public partial class HeroSelectionScreen : Form
    {
        XmlDocument heroListFile;

        public HeroSelectionScreen()
        {
            InitializeComponent();
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
                cmbHeroes.Items.Add(node.InnerText);
            }
        }
    }
}
