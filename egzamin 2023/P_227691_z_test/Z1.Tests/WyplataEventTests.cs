﻿using NUnit.Framework;
using System.Collections.Generic;

namespace Z1.Tests
{
    [TestFixture]
    class WyplataEventTests
    {
        [Test]
        [Category("WyplataEvent")]
        public void Wyplata_WykonujeOperacjeFinansowaEvent_ZPoprawnymiArgumentami()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");
            rachunek.Wpłać(1000);
            decimal kwota = 100;
            bool eventCalled = false;

            // Act
            rachunek.OnOperacjaFinansowa += (sender, e) =>
            {
                eventCalled = true;
                // Sprawdzamy czy event zosta³ wywo³any z prawid³owymi parametrami
                Assert.AreEqual(sender, rachunek);
                Assert.AreEqual(e.Kwota, kwota);
                Assert.AreEqual(e.Opis, "Wypłata środków");
            };


            rachunek.Wypłać(kwota);

            // Assert
            Assert.IsTrue(eventCalled, "OperacjaFinansowa event nie został wywołany.");
        }

        [Test]
        [Category("WyplataEvent")]
        public void Wyplata_WykonujeOperacjeFinansowaEvent_ZaDuzaKwotaWyplaty()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");
            rachunek.Wpłać(1000);
            decimal kwota = 10000;
            bool eventCalled = false;

            // Act
            rachunek.OnOperacjaFinansowa += (sender, e) =>
            {
                eventCalled = true;
                // Sprawdzamy czy event zosta³ wywo³any z prawid³owymi parametrami
                Assert.AreEqual(sender, rachunek);
                Assert.AreEqual(e.Kwota, kwota);
                Assert.AreEqual(e.Opis, "Błąd: Brak wystarczających środków na rachunku.");
            };


            rachunek.Wypłać(kwota);

            // Assert
            Assert.IsTrue(eventCalled, "OperacjaFinansowa event nie został wywołany.");
        }

        [Test]
        [Category("WyplataEvent")]
        public void Wyplata_WykonujeOperacjeFinansowaEvent_UjemnaKwotaWyplaty()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");
            rachunek.Wpłać(1000);
            decimal kwota = -1;
            bool eventCalled = false;

            // Act
            rachunek.OnOperacjaFinansowa += (sender, e) =>
            {
                eventCalled = true;
                // Sprawdzamy czy event zosta³ wywo³any z prawid³owymi parametrami
                Assert.AreEqual(sender, rachunek);
                Assert.AreEqual(e.Kwota, kwota);
                Assert.AreEqual(e.Opis, "Błąd: Brak wystarczających środków na rachunku.");
            };


            rachunek.Wypłać(kwota);

            // Assert
            Assert.IsTrue(eventCalled, "OperacjaFinansowa event nie zosta³ wywo³any.");
        }

        [Test]
        [Category("WyplataEvent")]
        public void Wyplata_GlobalnyRejestrOperacji_WykonujeOperacjeFinansowaEvent_ZPoprawnymiArgumentami()
        {
            // Arrange
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");

            List<OperacjaFinansowaEventArgs> globalnyRejestrOperacji = new List<OperacjaFinansowaEventArgs>();
            rachunek.OnOperacjaFinansowa += (sender, args) =>
            {
                globalnyRejestrOperacji.Add(args);
            };

            // Act
            rachunek.Wpłać(1000);
            rachunek.Wypłać(100);
            rachunek.Wypłać(50);

            // Assert
            Assert.AreEqual(3, globalnyRejestrOperacji.Count);
            Assert.AreEqual(100, globalnyRejestrOperacji[1].Kwota);
            Assert.AreEqual("Wypłata środków", globalnyRejestrOperacji[1].Opis);
            Assert.AreEqual(50, globalnyRejestrOperacji[2].Kwota);
            Assert.AreEqual("Wypłata środków", globalnyRejestrOperacji[2].Opis);
        }

        [Test]
        [Category("WyplataEvent")]
        public void Wyplata_GlobalnyRejestrOperacji_WykonujeOperacjeFinansowaEvent_Clone()
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
            rachunek.Wypłać(100);

            // Assert
            Assert.IsFalse(senderTest == rachunek);
        }
    }
}