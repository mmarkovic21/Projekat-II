using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
  public  class Kupovina
    {
        private int sifraRacuna;
        private int sifraKupca;
        private string nazivKupca;
        private int sifraArtikla;
        private string nazivArtikla;
        private int kolicinaArtikla;
        private int cenaArtikla;
        private string Datum;

        public int SifraRacuna { get => sifraRacuna; set => sifraRacuna = value; }
        public int SifraKupca { get => sifraKupca; set => sifraKupca = value; }
        public string NazivKupca { get => nazivKupca; set => nazivKupca = value; }
 
        public string Datum1 { get => Datum; set => Datum = value; }
        public int SifraArtikla { get => sifraArtikla; set => sifraArtikla = value; }
        public string NazivArtikla { get => nazivArtikla; set => nazivArtikla = value; }
        public int KolicinaArtikla { get => kolicinaArtikla; set => kolicinaArtikla = value; }
        public int CenaArtikla { get => cenaArtikla; set => cenaArtikla = value; }
    }
}
