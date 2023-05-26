using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Artikli
    {
        private int sifraArtikla;
        private string naziv;
        private int cena;
        private int kolicina;

        public int SifraArtikla { get => sifraArtikla; set => sifraArtikla = value; }
        public string Naziv { get => naziv; set => naziv = value; }

        public int Kolicina { get => kolicina; set => kolicina = value; }
        public int Cena { get => cena; set => cena = value; }
    }
}
