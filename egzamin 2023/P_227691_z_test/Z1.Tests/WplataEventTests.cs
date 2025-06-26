using NUnit.Framework;
using System.Collections.Generic;

namespace Z1.Tests
{
    [TestFixture]
    class WplataEventTests
    {
        [Test]
        [Category("WplataEvent")]
        public void Wplata_WykonujeOperacjeFinansowaEvent_ZPoprawnymiArgumentami()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");
            decimal kwota = 1000;
            bool eventCalled = false;

            // Act
            rachunek.OnOperacjaFinansowa += (sender, e) =>
            {
                eventCalled = true;
                // Sprawdzamy czy event zosta³ wywo³any z prawid³owymi parametrami
                Assert.AreEqual(sender, rachunek);
                Assert.AreEqual(e.Kwota, kwota);
                Assert.AreEqual(e.Opis, "Wpłata środków");
            };

            rachunek.Wpłać(kwota);

            // Assert
            Assert.IsTrue(eventCalled, "OperacjaFinansowa event nie został wywołany.");
        }

        [Test]
        [Category("WplataEvent")]
        public void Wplata_WykonujeOperacjeFinansowaEvent_ZUjemnaKwota()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");
            decimal kwota = -1000;
            bool eventCalled = false;

            // Act
            rachunek.OnOperacjaFinansowa += (sender, e) =>
            {
                eventCalled = true;
                // Sprawdzamy czy event zosta³ wywo³any z prawid³owymi parametrami
                Assert.AreEqual(sender, rachunek);
                Assert.AreEqual(e.Kwota, kwota);
                Assert.AreEqual(e.Opis, "Błąd: Próba wpłaty środków mniejszych bądź równych zero.");
            };

            rachunek.Wpłać(kwota);

            // Assert
            Assert.IsTrue(eventCalled, "OperacjaFinansowa event nie został wywołany.");
        }

        [Test]
        [Category("WplataEvent")]
        public void Wplata_WykonujeOperacjeFinansowaEvent_ZPustaListaInvoke()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");
            decimal kwota = -1000;
            bool eventCalled = false;

            rachunek.Wpłać(kwota);

            // Assert
            Assert.IsFalse(eventCalled);
        }

        [Test]
        [Category("WplataEvent")]
        public void Wplata_GlobalnyRejestrOperacji_WykonujeOperacjeFinansowaEvent_ZPoprawnymiArgumentami()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");

            List<OperacjaFinansowaEventArgs> globalnyRejestrOperacji = new List<OperacjaFinansowaEventArgs>();
            rachunek.OnOperacjaFinansowa += (sender, args) =>
            {
                globalnyRejestrOperacji.Add(args);
            };

            // Act
            rachunek.Wpłać(100);
            rachunek.Wpłać(50);

            // Assert
            Assert.AreEqual(2, globalnyRejestrOperacji.Count);
            Assert.AreEqual(100, globalnyRejestrOperacji[0].Kwota);
            Assert.AreEqual("Wpłata środków", globalnyRejestrOperacji[0].Opis);
            Assert.AreEqual(50, globalnyRejestrOperacji[1].Kwota);
            Assert.AreEqual("Wpłata środków", globalnyRejestrOperacji[1].Opis);
        }

        [Test]
        [Category("WplataEvent")]
        public void Wplata_GlobalnyRejestrOperacji_WykonujeOperacjeFinansowaEvent_Clone()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");
            object senderTest = null;

            List<OperacjaFinansowaEventArgs> globalnyRejestrOperacji = new List<OperacjaFinansowaEventArgs>();
            rachunek.OnOperacjaFinansowa += (sender, args) =>
            {
                globalnyRejestrOperacji.Add(args);
                senderTest = sender;
            };

            // Act
            rachunek.Wpłać(100);

            // Assert
            Assert.IsFalse(senderTest == rachunek);
        }
    }
}