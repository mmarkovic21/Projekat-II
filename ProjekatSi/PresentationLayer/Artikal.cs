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
    public partial class Artikal : Form
    {
        ArtikliBusiness artikliBusiness = new ArtikliBusiness();

        public Artikal()                                        //vidljivost buttona
        {
            InitializeComponent();

            button5.Visible = false;
            label5.Visible = false;
            textBox5.Visible = false;
        }

        private void Artikal_Load(object sender, EventArgs e)       //  pri samom ulazu u formu isisuje se lista artikala u listBoxu
        {
            this.Ispis();
        }


        int sifra;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)      //Pri selektovanju select se punni sa stringom a kasnije se string odseca do prvog razmaka
        {
            string select = listBox1.GetItemText(listBox1.SelectedItem);


            button5.Visible = true;
            label5.Visible = true;
            textBox5.Visible = true;

            sifra = int.Parse(select.Substring(0, select.IndexOf(" ")).Trim());


        }



        private void pictureBox1_Click(object sender, EventArgs e)              //dugme za izlaz
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Artikli a = new Artikli();

            a.Naziv = textBox9.Text;
            a.Kolicina = int.Parse(textBox7.Text);
            a.Cena = int.Parse(textBox8.Text);

            artikliBusiness.NoviArtikal(a);
            this.Ispis();
            textBox8.Clear();
            textBox9.Clear();
            textBox7.Clear();


        }

        private void button6_Click(object sender, EventArgs e)                  //Promena podataka artikla
        {
            Artikli a = new Artikli();

            a.SifraArtikla = int.Parse(textBox6.Text);
            a.Naziv = textBox9.Text;
            a.Kolicina = int.Parse(textBox7.Text);
            a.Cena = int.Parse(textBox8.Text);

            artikliBusiness.PromeniArtikal(a);

            Ispis();
            textBox6.Clear();

            textBox8.Clear();
            textBox9.Clear();
            textBox7.Clear();



        }

        private void button5_Click(object sender, EventArgs e)
        {




            artikliBusiness.PromeniKolicinuArtikla(sifra, int.Parse(textBox5.Text));
            Ispis();
            textBox5.Clear();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ispis();
        }

        

       

        private void Ispis()
        {
            listBox1.Items.Clear();
            List<Artikli> lista = this.artikliBusiness.VratiSveArtikle();

            foreach (Artikli a in lista)
            {
                listBox1.Items.Add(a.SifraArtikla + " - " + a.Naziv + " " + a.Kolicina + " " + a.Cena);
            }
        }

        
    }
}
