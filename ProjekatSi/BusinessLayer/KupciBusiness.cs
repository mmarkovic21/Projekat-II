using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class KupciBusiness
    {
        public KupciRepository kupciRepository;

        public KupciBusiness()
        {
            this.kupciRepository = new KupciRepository();
        }

        

        public List<Kupci> VratiSveKupce()
        {
            return this.kupciRepository.SviKupci();
        }

        public Boolean NoviKupac(Kupci k)
        {
            int n = 0;
            if (k != null)
            {
                n = this.kupciRepository.NoviKupac(k);
            }
            if (n > 0)
                return true;
            else
                return false;
        }

        public Boolean PromeniKupca(Kupci k)
        {
            int n = 0;
            if (k != null)
            {
                n = this.kupciRepository.PromeniKupca(k);
            }
            if (n > 0)
                return true;
            else
                return false;
        }


    }
}
