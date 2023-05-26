using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class KupovineBusiness
    {
        public KupovinaRepository kupovineRepository;

        public KupovineBusiness()
        {
            this.kupovineRepository = new KupovinaRepository();
        }

        public List<Kupovina> VratiSveKupovine()
        {
            return this.kupovineRepository.SveKupovine();
        }

        public List<Kupovina> Pretraga(int sifra)
        {
            return this.kupovineRepository.PretragaKupovine(sifra);
        }
        public Boolean BrisanjeKupovine(int racun, int kupac, int artikal)
        {
            int n = this.kupovineRepository.BrisanjeKupovine(racun, kupac, artikal);
            if (n > 0)
                return true;
            else
                return false;
        }

        public int UkupnaCena(int sifraRacuna)
        {
            List<Kupovina> lista = kupovineRepository.SveKupovine();

            int UkupnaCena = 0;

            foreach (Kupovina k in lista)
            {
                if (k.SifraRacuna == sifraRacuna)
                {
                    UkupnaCena += k.CenaArtikla;
                }
            }

            return UkupnaCena;
        }

        public Boolean DodavanjeKupovine(Boolean first, Kupovina k)
        {
            int n = 0;
            if (k != null)
            {
                n = this.kupovineRepository.DodavanjeKupovine(k, kupovineRepository.VratiSifru(first));
            }
            if (n > 0)
                return false;
            else
                return false;
        }

        public Kupovina convertToKupovine(Kupci kupci, string str)
        {
            Kupovina k = new Kupovina();

            string[] artikal = str.Split(new string[] { " - ", " " }, StringSplitOptions.RemoveEmptyEntries);

            k.SifraKupca = kupci.Sifra;
            k.NazivKupca = kupci.Naziv;
            k.SifraArtikla = int.Parse(artikal[0]);
            k.NazivArtikla = artikal[1];
            k.KolicinaArtikla = int.Parse(artikal[2]);
            k.CenaArtikla = int.Parse(artikal[3]);
            k.Datum1 = DateTime.Today.ToString("dd/MM/yyyy");

            return k;
        }
    }

}
