using BusinessLayer;
using DataLayer.Models;
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
    public partial class Kupac : Form
    {
        KupciBusiness kupciBusiness = new KupciBusiness();
        public Kupac()
        {
            InitializeComponent();

        }




        private void button1_Click(object sender, EventArgs e)
        {
            Kupci k = new Kupci();

            k.Naziv = textBox9.Text;
            k.Adresa = textBox2.Text;
            k.Pib = int.Parse(textBox3.Text);
            k.Kontakt = int.Parse(textBox1.Text);

            kupciBusiness.NoviKupac(k);
            this.IspisKupaca();
            textBox9.Clear();
            textBox2.Clear();
            textBox1.Clear();
            textBox3.Clear();
        }




        private void IspisKupaca()
        {
            listBox1.Items.Clear();
            List<Kupci> lista = this.kupciBusiness.VratiSveKupce();

            foreach (Kupci k in lista)
            {
                listBox1.Items.Add(k.Sifra + " - " + k.Naziv + " " + k.Adresa + " " + k.Kontakt);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kupci k = new Kupci();
            k.Sifra = int.Parse(textBox4.Text);
            k.Naziv = textBox9.Text;
            k.Adresa = textBox2.Text;
            k.Pib = int.Parse(textBox3.Text);
            k.Kontakt = int.Parse(textBox1.Text);

            kupciBusiness.PromeniKupca(k);
            this.IspisKupaca();
            textBox9.Clear();
            textBox2.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void Kupac_Load(object sender, EventArgs e)
        {
            IspisKupaca();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
