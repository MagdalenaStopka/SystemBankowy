using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace Bank.Tests
{
    [TestClass()]
    public class UnitTestKonto
    {
        
    }
}

namespace UnitTestProjectBank
{
    [TestClass]
    public class UnitTestKonto
    {
        [TestMethod]
        public void Konsturktor_PodawaneDwaArgumenty_OK()
        {
            //AAA
            //Arrange
            string klient = "Molenda";
            double kwota = 100.15;

            //Act
            Konto k = new Konto(klient, kwota);

            //Assert
            string expectedKlient = "Molenda";
            double expectedBilans = 100.15;

            Assert.IsNotNull(k);
            Assert.AreEqual(expectedBilans, k.Bilans);
            Assert.AreEqual(expectedKlient, k.Klient);

        }

        [TestMethod]
        public void Konsturktor_JedenArgumenty_OK()
        {
            //AAA
            //Arrange
            string klient = "Molenda";

            //Act
            Konto k = new Konto(klient);

            //Assert
            string expectedKlient = "Molenda";
            double expectedBilans = 0.0;

            Assert.IsNotNull(k);
            Assert.AreEqual(expectedBilans, k.Bilans);
            Assert.AreEqual(expectedKlient, k.Klient);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Konstruktor_UjemnaKwota_NieUtworzonyObiekt()
        {
            //Arrange
            string klient = "Molenda";
            double kwota = -100.15;

            //Act
            Konto k = null;
            k = new Konto(klient, kwota);
            

            //Assert
            //Assert.IsNull(k);
            
        }

        [TestMethod()]
        public void Wplata_NieujemnaKwota_BilansOK()
        {
            //Arrange
            double bilans = 100.15;
            Konto k = new Konto("Molenda", bilans);
            double kwota = 100.0;

            //Act
            k.Wplata(kwota);

            //Assert
            double expectedBilans = 200.15;
            Assert.AreEqual(expectedBilans, k.Bilans, 0.01);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Wplata_UjemnaKwota_ZgloszonyArgumentException()
        {
            Konto k = new Konto("KM", 100);
            double kwota = -10;

            //Act
            k.Wplata(kwota);

            //Assert
            //zgłoszony wyjątek

        }

        [TestMethod()]
        public void Wyplata_NieujemnaKwotaBilansWiekszyNizKwota_BilansOK()
        {
            Konto k = new Konto("KM", 100);
            double kwotaWyplaty = 40;

            k.Wyplata(kwotaWyplaty);

            double expectedBilans = 60;
            Assert.AreEqual(expectedBilans, k.Bilans, 0.01);       

        }

        [TestMethod()]
        public void Wyplata_NieujemnaKwotaBilansMniejszyNizKwota_BilansNieZmieniony()
        {
            Konto k = new Konto("KM", 100);
            double kwotaWyplaty = 140;

            k.Wyplata(kwotaWyplaty);

            //double expectedBilans = 100;
            //Assert.AreEqual(expectedBilans, k.Bilans, 0.01);


        }

    }
}
