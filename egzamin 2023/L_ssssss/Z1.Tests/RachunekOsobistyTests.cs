using NUnit.Framework;
using BankSystem;
using System;

namespace Z1.Tests
{
    [TestFixture]
    public class RachunekOsobistyTests
    {
        [Test]
        public void Constructor_ValidArguments_SetsPropertiesCorrectly()
        {
            var rachunek = new RachunekOsobisty("RO987", "Anna Nowak");
            Assert.That(rachunek.NumerRachunku, Is.EqualTo("RO987"));
            Assert.That(rachunek.Wlasciciel, Is.EqualTo("Anna Nowak"));
            Assert.That(rachunek.Saldo, Is.EqualTo(0m));
        }

        [Test]
        public void ImplicitConversion_ToRachunekFirmowy_CreatesNewInstanceWithCorrectProperties()
        {
            var rachunekOsobisty = new RachunekOsobisty("RO987", "Anna Nowak");
            rachunekOsobisty.Wplac(200m); // Saldo nie jest przenoszone w tej konwersji

            var rachunekFirmowy = (RachunekFirmowy)rachunekOsobisty;

            Assert.That(rachunekFirmowy, Is.Not.Null);
            Assert.That(rachunekFirmowy.NumerRachunku, Is.EqualTo("RO987"));
            Assert.That(rachunekFirmowy.Wlasciciel, Is.EqualTo("Anna Nowak"));
            Assert.That(rachunekFirmowy.NazwaFirmy, Is.EqualTo("DomyslnaNazwaFirmy")); // Zgodnie z założeniami w stubie
            Assert.That(rachunekFirmowy.Saldo, Is.EqualTo(0m)); // Saldo nie jest przenoszone w tej konwersji
            Assert.That(rachunekFirmowy, Is.Not.SameAs(rachunekOsobisty));
        }
    }
}