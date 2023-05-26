using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{


    public class ArtikliBusiness
    {


        private ArtikliRepository artikliRepository;


        public ArtikliBusiness()
        {
            this.artikliRepository = new ArtikliRepository();
        }

        public List<Artikli> VratiSveArtikle()
        {
            return this.artikliRepository.SviArtikli();
        }
        public Boolean NoviArtikal(Artikli a)
        {


            int n = 0;
            if (a != null)
            {
                n = this.artikliRepository.NoviArtikal(a);
            }
            if (n > 0)
            {
                return true;
            }
            return false;

        }

        public Boolean PromeniArtikal(Artikli a)
        {
            int n = 0;
            if (a != null)
            {
                n = this.artikliRepository.PromeniArtikal(a);
            }
            if (n > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean PromeniKolicinuArtikla(int sifra, int novaKolicina)
        {
            int n = this.artikliRepository.PromeniKolicinuArtikla(sifra, novaKolicina);

            if (n > 0)
            {
                return true;
            }
            return false;
        }

        public void ObrisiArtikal(Artikli a)
        {
            this.artikliRepository.ObrisiArtikal(a);
        }

    }
}
