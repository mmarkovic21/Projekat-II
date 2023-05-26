using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Glavna : Form
    {
        public Glavna()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void kupac_Click(object sender, EventArgs e)
        {
            Kupac kupac = new Kupac();
            kupac.Show();

        }

        private void artikal_Click(object sender, EventArgs e)
        {
            Artikal artikal = new Artikal();
            artikal.Show();
        }

        private void kupovina_Click(object sender, EventArgs e)
        {
            Kupovina kupovina = new Kupovina();
            kupovina.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
