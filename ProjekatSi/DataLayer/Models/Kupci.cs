using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Kupci
    {
        private int sifra;
        private string naziv;
        private string adresa;
        private int pib;
        private int kontakt;

        public int Sifra { get => sifra; set => sifra = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public int Pib { get => pib; set => pib = value; }
        public int Kontakt { get => kontakt; set => kontakt = value; }
    }
}
