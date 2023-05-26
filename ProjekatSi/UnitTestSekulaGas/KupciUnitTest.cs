using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Models;
using BusinessLayer;
using System.Linq;

namespace UnitTestSekulaGas
{

    [TestClass]
    public class KupciUnitTest
    {

        Random r = new Random();
        Kupci k = new Kupci();
        KupciBusiness kb = new KupciBusiness();
        [TestInitialize]
        public void TestInit()
        {
            k.Kontakt = r.Next(10, 20);
            k.Pib = r.Next(1, 10);
            k.Naziv = "Kupac";
            k.Adresa = "Adresa";
            kb.PromeniKupca(k);
            k.Sifra = kb.VratiSveKupce().Where(tmp => tmp.Naziv == k.Naziv).ToList()[0].Sifra;
        }

        [TestMethod]
        public void TestInsert()
        {
            if (!kb.VratiSveKupce().Exists(tmp => tmp.Sifra == k.Sifra))
                Assert.Fail("Kupac nije unesen u bazu!");
        }

        [TestMethod]
        public void TestUpdate()
        {
            k.Kontakt = r.Next(10, 20);
            k.Pib = r.Next(1, 10);
            kb.PromeniKupca(k);
            if (!kb.VratiSveKupce().Exists(tmp => tmp.Sifra == k.Sifra && tmp.Pib == k.Pib && tmp.Kontakt == k.Kontakt))
            {
                Assert.Fail("Kupac nije promenjen u bazi!");
            }
        }

        

        [TestCleanup]
        public void TestClean()
        {

        }


    }
}