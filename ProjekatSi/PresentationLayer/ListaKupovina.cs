using BusinessLayer;
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
    public partial class ListaKupovina : Form
    {
        KupovineBusiness kupovinaBusiness = new KupovineBusiness();

        public ListaKupovina()
        {
            InitializeComponent();
           
        }

        private void ListaKupovina_Load(object sender, EventArgs e)
        {
            IspisListe();
        }

        public void IspisListe()
        {
            listBox1.Items.Clear();
            List<DataLayer.Models.Kupovina> lista = this.kupovinaBusiness.VratiSveKupovine();


            foreach (DataLayer.Models.Kupovina a in lista)
            {
                listBox1.Items.Add("Sifra racuna - " + a.SifraRacuna + "     Sifra kupca -" + a.SifraKupca + "     Artikal - " + a.NazivArtikla + "     Kolicina - " + a.KolicinaArtikla + "      Cena - " + a.CenaArtikla + "      Datum - " + a.Datum1);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
