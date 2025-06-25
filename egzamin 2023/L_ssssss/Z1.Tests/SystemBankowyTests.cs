using NUnit.Framework;
using BankSystem;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace Z1.Tests
{
    [TestFixture]
    public class SystemBankowyTests
    {
        private SystemBankowy _systemBankowy;
        private RachunekOsobisty _rachunek1;
        private RachunekFirmowy _rachunek2;

        [SetUp]
        public void SetUp()
        {
            _systemBankowy = new SystemBankowy();
            _rachunek1 = new RachunekOsobisty("1111", "Adam Nowak");
            _rachunek2 = new RachunekFirmowy("2222", "Bank Sp. z o.o.", "Bank");

            _systemBankowy.DodajRachunekBankowy(_rachunek1);
            _systemBankowy.DodajRachunekBankowy(_rachunek2);
        }

        [Test]
        public void DodajRachunekBankowy_ValidRachunek_AddsToList()
        {
            var nowyRachunek = new RachunekOsobisty("3333", "Ewa Zielinska");
            _systemBankowy.DodajRachunekBankowy(nowyRachunek);
            Assert.That(_systemBankowy.RachunkiBankowe, Contains.Item(nowyRachunek));
            Assert.That(_systemBankowy.RachunkiBankowe.Count, Is.EqualTo(3));
        }

        [Test]
        public void DodajRachunekBankowy_NullRachunek_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _systemBankowy.DodajRachunekBankowy(null));
        }

        [Test]
        public void DodajRachunekBankowy_DuplicateRachunek_ThrowsInvalidOperationException()
        {
            var duplicateRachunek = new RachunekOsobisty("1111", "Adam Nowak");
            Assert.Throws<InvalidOperationException>(() => _systemBankowy.DodajRachunekBankowy(duplicateRachunek));
        }

        [Test]
        public void UsunRachunekBankowy_ExistingRachunek_RemovesFromList()
        {
            bool removed = _systemBankowy.UsunRachunekBankowy(_rachunek1);
            Assert.That(removed, Is.True);
            Assert.That(_systemBankowy.RachunkiBankowe, Does.Not.Contain(_rachunek1));
            Assert.That(_systemBankowy.RachunkiBankowe.Count, Is.EqualTo(1));
        }

        [Test]
        public void UsunRachunekBankowy_NonExistingRachunek_ReturnsFalse()
        {
            var nonExistingRachunek = new RachunekOsobisty("9999", "Nieistniejacy");
            bool removed = _systemBankowy.UsunRachunekBankowy(nonExistingRachunek);
            Assert.That(removed, Is.False);
            Assert.That(_systemBankowy.RachunkiBankowe.Count, Is.EqualTo(2));
        }

        [Test]
        public void UsunRachunekBankowy_NullRachunek_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _systemBankowy.UsunRachunekBankowy(null));
        }

        [Test]
        public void Wplac_ValidAmount_IncreasesSaldoAndAddsToHistory()
        {
            _systemBankowy.Wplac("1111", 100m, "Testowa wpłata");
            Assert.That(_rachunek1.Saldo, Is.EqualTo(100m));
            Assert.That(_systemBankowy.HistoriaTransakcji.Count, Is.EqualTo(1));
            Assert.That(_systemBankowy.HistoriaTransakcji[0].Kwota, Is.EqualTo(100m));
            Assert.That(_systemBankowy.HistoriaTransakcji[0].Opis, Contains.Substring("Testowa wpłata"));
        }

        [Test]
        public void Wplac_NonExistingRachunek_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _systemBankowy.Wplac("9999", 50m));
        }

        [Test]
        public void Wplac_ZeroAmount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _systemBankowy.Wplac("1111", 0m));
        }

        [Test]
        public void Wypłac_ValidAmount_DecreasesSaldoAndAddsToHistory()
        {
            _systemBankowy.Wplac("1111", 200m);
            _systemBankowy.Wyplac("1111", 50m, "Testowa wypłata");
            Assert.That(_rachunek1.Saldo, Is.EqualTo(150m));
            Assert.That(_systemBankowy.HistoriaTransakcji.Count, Is.EqualTo(2)); // Wpłata + Wypłata
            Assert.That(_systemBankowy.HistoriaTransakcji[1].Kwota, Is.EqualTo(50m));
            Assert.That(_systemBankowy.HistoriaTransakcji[1].Opis, Contains.Substring("Testowa wypłata"));
        }

        [Test]
        public void Wypłac_NonExistingRachunek_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _systemBankowy.Wyplac("9999", 50m));
        }

        [Test]
        public void Wypłac_InsufficientFunds_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _systemBankowy.Wyplac("1111", 50m)); // Saldo początkowe 0
        }

        [Test]
        public void Przelew_ValidTransfer_UpdatesSaldosAndAddsToHistory()
        {
            _systemBankowy.Wplac("1111", 300m);
            _systemBankowy.Przelew("1111", "2222", 100m, "Przelew testowy");

            Assert.That(_rachunek1.Saldo, Is.EqualTo(200m));
            Assert.That(_rachunek2.Saldo, Is.EqualTo(100m));
            Assert.That(_systemBankowy.HistoriaTransakcji.Count, Is.EqualTo(2)); // Wpłata + Przelew
            Assert.That(_systemBankowy.HistoriaTransakcji[1].Kwota, Is.EqualTo(100m));
            Assert.That(_systemBankowy.HistoriaTransakcji[1].Opis, Contains.Substring("Przelew testowy"));
        }

        [Test]
        public void Przelew_SameAccount_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _systemBankowy.Przelew("1111", "1111", 50m));
        }

        [Test]
        public void Przelew_NonExistingSourceRachunek_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _systemBankowy.Przelew("9999", "2222", 50m));
        }

        [Test]
        public void Przelew_NonExistingDestinationRachunek_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _systemBankowy.Przelew("1111", "9999", 50m));
        }

        [Test]
        public void Przelew_InsufficientFunds_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _systemBankowy.Przelew("1111", "2222", 50m)); // Saldo początkowe 0
        }

        [Test]
        public void OnOperacjaFinansowa_EventIsRaisedOnWplac()
        {
            bool eventRaised = false;
            _systemBankowy.OperacjaFinansowa += (sender, args) =>
            {
                eventRaised = true;
                Assert.That(args.Kwota, Is.EqualTo(50m));
                Assert.That(args.Opis, Contains.Substring("Wpłata"));
            };
            _systemBankowy.Wplac("1111", 50m);
            Assert.That(eventRaised, Is.True);
        }

        [Test]
        public void OnOperacjaFinansowa_EventIsRaisedOnWyplac()
        {
            _systemBankowy.Wplac("1111", 100m); // Aby było z czego wypłacić
            bool eventRaised = false;
            _systemBankowy.OperacjaFinansowa += (sender, args) =>
            {
                eventRaised = true;
                Assert.That(args.Kwota, Is.EqualTo(25m));
                Assert.That(args.Opis, Contains.Substring("Wypłata"));
            };
            _systemBankowy.Wyplac("1111", 25m);
            Assert.That(eventRaised, Is.True);
        }

        [Test]
        public void OnOperacjaFinansowa_EventIsRaisedOnPrzelew()
        {
            _systemBankowy.Wplac("1111", 200m); // Aby było z czego przelać
            bool eventRaised = false;
            _systemBankowy.OperacjaFinansowa += (sender, args) =>
            {
                eventRaised = true;
                Assert.That(args.Kwota, Is.EqualTo(75m));
                Assert.That(args.Opis, Contains.Substring("Przelew"));
            };
            _systemBankowy.Przelew("1111", "2222", 75m);
            Assert.That(eventRaised, Is.True);
        }

        [Test]
        public void Serializuj_ReturnsJsonString()
        {
            _rachunek1.Wplac(100);
            _rachunek2.Wplac(200);
            var json = _systemBankowy.Serializuj();
            Assert.That(json, Is.Not.Empty);
            Assert.That(json, Does.Contain("1111"));
            Assert.That(json, Does.Contain("Adam Nowak"));
            Assert.That(json, Does.Contain("100"));
            Assert.That(json, Does.Contain("2222"));
            Assert.That(json, Does.Contain("Bank Sp. z o.o."));
            Assert.That(json, Does.Contain("200"));
        }

        [Test]
        public void Deserializuj_RestoresRachunkiBankowe()
        {
            _rachunek1.Wplac(100);
            _rachunek2.Wplac(200);
            var json = _systemBankowy.Serializuj();

            var newSystem = new SystemBankowy();
            newSystem.Deserializuj(json);

            Assert.That(newSystem.RachunkiBankowe.Count, Is.EqualTo(2));
            var deserializedRachunek1 = newSystem.RachunkiBankowe.FirstOrDefault(r => r.NumerRachunku == "1111");
            var deserializedRachunek2 = newSystem.RachunkiBankowe.FirstOrDefault(r => r.NumerRachunku == "2222");

            Assert.That(deserializedRachunek1, Is.Not.Null);
            Assert.That(deserializedRachunek1.Wlasciciel, Is.EqualTo("Adam Nowak"));
            Assert.That(deserializedRachunek1.Saldo, Is.EqualTo(100m)); // Sprawdzamy czy saldo zostało przywrócone

            Assert.That(deserializedRachunek2, Is.Not.Null);
            Assert.That(deserializedRachunek2.Wlasciciel, Is.EqualTo("Bank Sp. z o.o."));
            Assert.That(deserializedRachunek2.Saldo, Is.EqualTo(200m)); // Sprawdzamy czy saldo zostało przywrócone
        }
    }
}