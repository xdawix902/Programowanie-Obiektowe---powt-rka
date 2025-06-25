using NUnit.Framework;
using BankSystem;
using System;

namespace Z1.Tests
{
    [TestFixture]
    public class RachunekFirmowyTests
    {
        [Test]
        public void Constructor_ValidArguments_SetsPropertiesCorrectly()
        {
            var rachunek = new RachunekFirmowy("RF123", "Firma Testowa Sp. z o.o.", "Firma Testowa");
            Assert.That(rachunek.NumerRachunku, Is.EqualTo("RF123"));
            Assert.That(rachunek.Wlasciciel, Is.EqualTo("Firma Testowa Sp. z o.o."));
            Assert.That(rachunek.NazwaFirmy, Is.EqualTo("Firma Testowa"));
            Assert.That(rachunek.Saldo, Is.EqualTo(0m));
        }

        [Test]
        public void Constructor_EmptyNazwaFirmy_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new RachunekFirmowy("RF123", "Firma Testowa Sp. z o.o.", ""));
        }

        [Test]
        public void Constructor_NullNazwaFirmy_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new RachunekFirmowy("RF123", "Firma Testowa Sp. z o.o.", null));
        }

        [Test]
        public void ExplicitConversion_ToRachunekOsobisty_CreatesNewInstanceWithCorrectProperties()
        {
            var rachunekFirmowy = new RachunekFirmowy("RF123", "Jan Kowalski", "Kowalski Sp. z o.o.");
            rachunekFirmowy.Wplac(500m); // Saldo nie jest przenoszone w tej konwersji

            var rachunekOsobisty = (RachunekOsobisty)rachunekFirmowy;

            Assert.That(rachunekOsobisty, Is.Not.Null);
            Assert.That(rachunekOsobisty.NumerRachunku, Is.EqualTo("RF123"));
            Assert.That(rachunekOsobisty.Wlasciciel, Is.EqualTo("Jan Kowalski"));
            Assert.That(rachunekOsobisty.Saldo, Is.EqualTo(0m)); // Saldo nie jest przenoszone w tej konwersji
            Assert.That(rachunekOsobisty, Is.Not.SameAs(rachunekFirmowy));
        }
    }
}