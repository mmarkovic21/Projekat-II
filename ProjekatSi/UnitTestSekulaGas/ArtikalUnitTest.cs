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
    public class ArtikalUnitTest
    {
        Random r = new Random();
        Artikli a = new Artikli();
        ArtikliBusiness ab = new ArtikliBusiness();
        [TestInitialize]
        public void TestInit()
        {
            a.Cena = r.Next(100, 1000);
            a.Kolicina = r.Next(1, 10);
            a.Naziv = "Artikal";
            ab.NoviArtikal(a);
            a.SifraArtikla = ab.VratiSveArtikle().Where(tmp => tmp.Naziv == a.Naziv).ToList()[0].SifraArtikla;
        }

        [TestMethod]
        public void TestInsert()
        {
            if (!ab.VratiSveArtikle().Exists(tmp => tmp.SifraArtikla == a.SifraArtikla))
                Assert.Fail("Artikal nije unesen u bazu!");
        }

        [TestMethod]
        public void TestUpdate()
        {
            a.Cena = r.Next(100, 1000);
            a.Kolicina = r.Next(1, 10);
            ab.PromeniArtikal(a);
            if (!ab.VratiSveArtikle().Exists(tmp => tmp.SifraArtikla == a.SifraArtikla && tmp.Cena==a.Cena && tmp.Kolicina==a.Kolicina))
                Assert.Fail("Artikal nije promenjen u bazi!");
        }

        [TestMethod]
        public void TestDelete()
        {
            ab.ObrisiArtikal(a);
            if (ab.VratiSveArtikle().Exists(tmp => tmp.SifraArtikla == a.SifraArtikla))
                Assert.Fail("Artikal nije obrisan!");
        }

        [TestCleanup]
        public void TestClean()
        {
            ab.ObrisiArtikal(a);
        }
    }
}
