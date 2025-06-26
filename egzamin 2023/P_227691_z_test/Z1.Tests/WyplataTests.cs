using NUnit.Framework;
using System.Reflection;

namespace Z1.Tests
{
    [TestFixture]
    class WyplataTests
    {
        [Test]
        [Category("Wypłata")]
        public void Wypłata_PoprawnaKwota_WypłataWykonanaPoprawnie()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");

            // Act
            var res = rachunek.Wpłać(100);
            rachunek.Wypłać(100);

            // Assert
            decimal saldoKoñcowe = rachunek.Saldo;
            Assert.AreEqual(0, saldoKoñcowe);
            Assert.IsTrue(res);
        }

        [Test]
        [Category("Wypłata")]
        public void Wypłata_NiepoprawnaKwota_BłądBrakuŒrodków()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");
            decimal saldoPoczątkowe = rachunek.Saldo;
            decimal kwota = 1000;

            // Act
            var res = rachunek.Wypłać(kwota);

            // Assert
            decimal saldoKoñcowe = rachunek.Saldo;
            Assert.AreEqual(saldoPoczątkowe, saldoKoñcowe);
            Assert.IsFalse(res);
        }

        [Test]
        [Category("Wypłata")]
        public void Wypłata_NiepoprawnaKwota_BłądPróbaWypłatyZaPomocąUjemnejKwoty()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");
            decimal saldoPoczątkowe = rachunek.Saldo;
            decimal kwota = -50;

            // Act
            var res = rachunek.Wypłać(kwota);

            // Assert
            decimal saldoKoñcowe = rachunek.Saldo;
            Assert.AreEqual(saldoPoczątkowe, saldoKoñcowe);
            Assert.IsFalse(res);
        }
    }
}