using NUnit.Framework;
using System.Reflection;
using Z1;


namespace Z1.Tests
{
    [TestFixture]
    class WplataTests
    {
        [Test]
        [Category("Wpłata")]
        public void Wpłata_PoprawnaKwota_WpłataWykonanaPoprawnie()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");
            // Act
            var res = rachunek.Wpłać(100);
            decimal aktualneSaldo = rachunek.Saldo;

            // Assert
            Assert.AreEqual(100, aktualneSaldo);
            Assert.IsTrue(res);
        }


        [Test]
        [Category("Wpłata")]
        public void Wpłata_NiepoprawnaKwota_BłądPróbaWpłatyZaPomocąUjemnejKwoty()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");
            // Act
            var res = rachunek.Wpłać(-100);
            decimal aktualneSaldo = rachunek.Saldo;

            // Assert
            Assert.AreEqual(0, aktualneSaldo);
            Assert.IsFalse(res);
        }

        [Test]
        [Category("Wp³ata")]
        public void Wpłata_WielokrotnaPoprawnaKwota_WpłataWykonanaPoprawnie()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");
            // Act
            rachunek.Wpłać(100);
            rachunek.Wpłać(100);
            rachunek.Wpłać(100);
            var res = rachunek.Wpłać(100);
            decimal aktualneSaldo = rachunek.Saldo;

            // Assert
            Assert.AreEqual(400, aktualneSaldo);
            Assert.IsTrue(res);
        }

        [Test]
        [Category("Wpłata")]
        public void Wpłata_WielokrotnaNiepoprawnaKwota_BłądPróbaWpłatyZaPomocąUjemnejKwoty()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");
            // Act
            rachunek.Wpłać(100);
            rachunek.Wpłać(-100);
            var res = rachunek.Wpłać(-100);
            rachunek.Wpłać(0);
            decimal aktualneSaldo = rachunek.Saldo;

            // Assert
            Assert.AreEqual(100, aktualneSaldo);
            Assert.IsFalse(res);
        }
    }
}