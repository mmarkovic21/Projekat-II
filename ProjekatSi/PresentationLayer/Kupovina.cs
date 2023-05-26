using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Kupovina : Form
    {

        KupovineBusiness kupovinaBusiness = new KupovineBusiness();
        KupciBusiness kupciBusiness = new KupciBusiness();
        ArtikliBusiness artikliBusiness = new ArtikliBusiness();

        Kupci trenutniKupac = new Kupci();
        Artikli trenutniArtikal = new Artikli();
        int proveri, proveriSifra;
        List<Artikli> listaSelektovanih = new List<Artikli>();
        bool isKupci = false;
        public Kupovina()
        {
            InitializeComponent();
            artikalKolicina.Visible = false;
            
            IzaberiKupca.Visible = false;

        }


        private void Kupovina_Load(object sender, EventArgs e)
        {
            IspisKupaca();
        }

        private void IzaberiKupca_Click(object sender, EventArgs e)
        {
            string nesto = listBox2.GetItemText(listBox2.SelectedItem);

            IzaberiKupca.Visible = false;

            foreach (Kupci k in kupciBusiness.VratiSveKupce())
            {
                if (int.Parse(nesto.Substring(0, nesto.IndexOf(" ")).Trim()) == k.Sifra)
                {
                    trenutniKupac.Sifra = k.Sifra;
                    trenutniKupac.Naziv = k.Naziv;
                    trenutniKupac.Adresa = k.Adresa;
                    trenutniKupac.Pib = k.Pib;
                    trenutniKupac.Kontakt = k.Kontakt;
                    break;
                }
            }

            isKupci = true;
            IspisArtikala();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isKupci)
            {
                string nesto = listBox2.GetItemText(listBox2.SelectedItem);

                IzaberiKupca.Visible = true;

                foreach (Kupci k in kupciBusiness.VratiSveKupce())
                {
                    try
                    {
                        if (int.Parse(nesto.Substring(0, nesto.IndexOf(" ")).Trim()) == k.Sifra)
                        {
                            trenutniKupac.Sifra = k.Sifra;
                            trenutniKupac.Naziv = k.Naziv;
                            trenutniKupac.Adresa = k.Adresa;
                            trenutniKupac.Pib = k.Pib;
                            trenutniKupac.Kontakt = k.Kontakt;
                            break;
                        }
                    }
                    catch
                    {
                        return;
                    }
                }

            }
            else
            {
                string nesto = listBox2.GetItemText(listBox2.SelectedItem);


                foreach (Artikli a in artikliBusiness.VratiSveArtikle())
                {
                    try
                    {
                        if (int.Parse(nesto.Substring(0, nesto.IndexOf(" ")).Trim()) == a.SifraArtikla)
                        {
                            trenutniArtikal.SifraArtikla = a.SifraArtikla;
                            trenutniArtikal.Naziv = a.Naziv;
                            trenutniArtikal.Cena = a.Cena;
                            trenutniArtikal.Kolicina = a.Kolicina;

                            proveriSifra = a.SifraArtikla;
                            proveri = a.Kolicina;
                            break;
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
                artikalKolicina.Visible = true;
            }
        }
        private void IspisKupaca()
        {
            listBox2.Items.Clear();

            List<Kupci> lista = this.kupciBusiness.VratiSveKupce();

            foreach (Kupci k in lista)
            {
                listBox2.Items.Add(k.Sifra + " - " + k.Naziv + " " + k.Adresa + " " + k.Kontakt);
            }
        }

        private void IspisArtikala()
        {
            listBox2.Items.Clear();
            List<Artikli> lista = this.artikliBusiness.VratiSveArtikle();

            foreach (Artikli a in lista)
            {
                listBox2.Items.Add(a.SifraArtikla + " - " + a.Naziv + " cena: " + a.Cena + " kolicina: " + a.Kolicina);
            }
        }

        private void IspisIzabranih()
        {
            listBox1.Items.Clear();

            foreach (Artikli a in listaSelektovanih)
            {
                listBox1.Items.Add(a.SifraArtikla + " - " + a.Naziv + " " + a.Kolicina + " " + a.Cena);
            }
        }
        private void artikalKolicina_Click(object sender, EventArgs e)
        {
            int kolicina;
            if (textBox3.TextLength == 0)
            {
                textBox3.Text = "1";
            }
            try
            {
                kolicina = int.Parse(textBox3.Text);
            }
            catch
            {
                return;
            }

            if (kolicina > proveri)
            {
                MessageBox.Show("Nedovoljna kolicina na stanju\nPotrebno je poruciti", "Greska");
                return;
            }
            trenutniArtikal.Kolicina = int.Parse(textBox3.Text);
            listaSelektovanih.Add(trenutniArtikal);
            artikliBusiness.PromeniKolicinuArtikla(proveriSifra, proveri - kolicina);
            trenutniArtikal = new Artikli();
            artikalKolicina.Visible = false;
            IspisIzabranih();
            IspisArtikala();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Boolean first = true;
            foreach (string item in listBox1.Items)
            {
                kupovinaBusiness.DodavanjeKupovine(first, kupovinaBusiness.convertToKupovine(trenutniKupac, item.ToString()));
                if (first)
                {
                    first = false;
                }
            }
            listBox1.Items.Clear();
            listaSelektovanih.Clear();
        }

        private void izvrsiKupovinu_Click(object sender, EventArgs e)
        {
            ListaKupovina listaK = new ListaKupovina();
            listaK.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void obrisiArtikal_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            int sifra = int.Parse(textBox1.Text);
            List<DataLayer.Models.Kupovina> lista = this.kupovinaBusiness.Pretraga(sifra);


            foreach (DataLayer.Models.Kupovina a in lista)
            {
                listBox2.Items.Add(a.SifraRacuna + " - " + a.SifraKupca + " " + a.NazivArtikla + " " + a.KolicinaArtikla + " " + a.CenaArtikla + " " + a.Datum1);
            }


        }

        public void ispisKupovina()
        {
            listBox1.Items.Clear();
            List<DataLayer.Models.Kupovina> lista = this.kupovinaBusiness.VratiSveKupovine();


            foreach (DataLayer.Models.Kupovina a in lista)
            {
                listBox1.Items.Add(a.SifraRacuna + " - " + a.SifraKupca + " " + a.NazivArtikla + " " + a.KolicinaArtikla + " " + a.CenaArtikla + " " + a.Datum1 );
            }
        }
    }
}
