using NUnit.Framework;
using BankSystem;
using System;

namespace Z1.Tests
{
    [TestFixture]
    public class RachunekBankowyTests
    {
        private class TestRachunekBankowy : RachunekBankowy
        {
            public TestRachunekBankowy(string numerRachunku, string wlasciciel)
                : base(numerRachunku, wlasciciel)
            {
            }
        }

        [Test]
        public void Constructor_ValidArguments_SetsPropertiesCorrectly()
        {
            var rachunek = new TestRachunekBankowy("1234567890", "Jan Kowalski");
            Assert.That(rachunek.NumerRachunku, Is.EqualTo("1234567890"));
            Assert.That(rachunek.Wlasciciel, Is.EqualTo("Jan Kowalski"));
            Assert.That(rachunek.Saldo, Is.EqualTo(0m));
        }

        [Test]
        public void Constructor_EmptyNumerRachunku_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new TestRachunekBankowy("", "Jan Kowalski"));
        }

        [Test]
        public void Constructor_NullNumerRachunku_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new TestRachunekBankowy(null, "Jan Kowalski"));
        }

        [Test]
        public void Constructor_EmptyWlasciciel_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new TestRachunekBankowy("1234567890", ""));
        }

        [Test]
        public void Constructor_NullWlasciciel_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new TestRachunekBankowy("1234567890", null));
        }

        [Test]
        public void Wplac_PositiveAmount_IncreasesSaldo()
        {
            var rachunek = new TestRachunekBankowy("123", "Test");
            rachunek.Wplac(100m);
            Assert.That(rachunek.Saldo, Is.EqualTo(100m));
        }

        [Test]
        public void Wplac_ZeroAmount_ThrowsArgumentOutOfRangeException()
        {
            var rachunek = new TestRachunekBankowy("123", "Test");
            Assert.Throws<ArgumentOutOfRangeException>(() => rachunek.Wplac(0m));
        }

        [Test]
        public void Wplac_NegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            var rachunek = new TestRachunekBankowy("123", "Test");
            Assert.Throws<ArgumentOutOfRangeException>(() => rachunek.Wplac(-10m));
        }

        [Test]
        public void Wyplac_PositiveAmount_DecreasesSaldo()
        {
            var rachunek = new TestRachunekBankowy("123", "Test");
            rachunek.Wplac(200m);
            rachunek.Wyplac(50m);
            Assert.That(rachunek.Saldo, Is.EqualTo(150m));
        }

        [Test]
        public void Wyplac_ZeroAmount_ThrowsArgumentOutOfRangeException()
        {
            var rachunek = new TestRachunekBankowy("123", "Test");
            Assert.Throws<ArgumentOutOfRangeException>(() => rachunek.Wyplac(0m));
        }

        [Test]
        public void Wyplac_NegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            var rachunek = new TestRachunekBankowy("123", "Test");
            Assert.Throws<ArgumentOutOfRangeException>(() => rachunek.Wyplac(-10m));
        }

        [Test]
        public void Wyplac_InsufficientFunds_ThrowsInvalidOperationException()
        {
            var rachunek = new TestRachunekBankowy("123", "Test");
            rachunek.Wplac(50m);
            Assert.Throws<InvalidOperationException>(() => rachunek.Wyplac(100m));
        }

        [Test]
        public void CompareTo_SameNumerRachunku_ReturnsZero()
        {
            var rachunek1 = new TestRachunekBankowy("ABC", "Test");
            var rachunek2 = new TestRachunekBankowy("ABC", "Another Test");
            Assert.That(rachunek1.CompareTo(rachunek2), Is.EqualTo(0));
        }

        [Test]
        public void CompareTo_DifferentNumerRachunku_ReturnsCorrectValue()
        {
            var rachunek1 = new TestRachunekBankowy("ABC", "Test");
            var rachunek2 = new TestRachunekBankowy("DEF", "Test");
            Assert.That(rachunek1.CompareTo(rachunek2), Is.LessThan(0));
            Assert.That(rachunek2.CompareTo(rachunek1), Is.GreaterThan(0));
        }

        [Test]
        public void CompareTo_NullOther_ReturnsPositiveValue()
        {
            var rachunek = new TestRachunekBankowy("ABC", "Test");
            Assert.That(rachunek.CompareTo(null), Is.GreaterThan(0));
        }

        [Test]
        public void Equals_SameNumerRachunku_ReturnsTrue()
        {
            var rachunek1 = new TestRachunekBankowy("ABC", "Test");
            var rachunek2 = new TestRachunekBankowy("ABC", "Another Test");
            Assert.That(rachunek1.Equals(rachunek2), Is.True);
        }

        [Test]
        public void Equals_DifferentNumerRachunku_ReturnsFalse()
        {
            var rachunek1 = new TestRachunekBankowy("ABC", "Test");
            var rachunek2 = new TestRachunekBankowy("DEF", "Test");
            Assert.That(rachunek1.Equals(rachunek2), Is.False);
        }

        [Test]
        public void Equals_NullObject_ReturnsFalse()
        {
            var rachunek = new TestRachunekBankowy("ABC", "Test");
            Assert.That(rachunek.Equals(null), Is.False);
        }

        [Test]
        public void Equals_DifferentType_ReturnsFalse()
        {
            var rachunek = new TestRachunekBankowy("ABC", "Test");
            Assert.That(rachunek.Equals("some string"), Is.False);
        }

        [Test]
        public void GetHashCode_SameNumerRachunku_ReturnsSameHashCode()
        {
            var rachunek1 = new TestRachunekBankowy("ABC", "Test");
            var rachunek2 = new TestRachunekBankowy("ABC", "Another Test");
            Assert.That(rachunek1.GetHashCode(), Is.EqualTo(rachunek2.GetHashCode()));
        }

        [Test]
        public void GetHashCode_DifferentNumerRachunku_ReturnsDifferentHashCode()
        {
            var rachunek1 = new TestRachunekBankowy("ABC", "Test");
            var rachunek2 = new TestRachunekBankowy("DEF", "Test");
            Assert.That(rachunek1.GetHashCode(), Is.Not.EqualTo(rachunek2.GetHashCode()));
        }

        [Test]
        public void Clone_CreatesShallowCopy()
        {
            var originalRachunek = new TestRachunekBankowy("123", "Original");
            originalRachunek.Wplac(100m);

            var clonedRachunek = (TestRachunekBankowy)originalRachunek.Clone();

            Assert.That(clonedRachunek.NumerRachunku, Is.EqualTo(originalRachunek.NumerRachunku));
            Assert.That(clonedRachunek.Wlasciciel, Is.EqualTo(originalRachunek.Wlasciciel));
            Assert.That(clonedRachunek.Saldo, Is.EqualTo(originalRachunek.Saldo));
            Assert.That(clonedRachunek, Is.Not.SameAs(originalRachunek)); // Should be a new instance
        }

        [Test]
        public void Clone_ModifyingCloneDoesNotAffectOriginalSaldo()
        {
            var originalRachunek = new TestRachunekBankowy("123", "Original");
            originalRachunek.Wplac(100m);

            var clonedRachunek = (TestRachunekBankowy)originalRachunek.Clone();
            clonedRachunek.Wplac(50m);

            Assert.That(originalRachunek.Saldo, Is.EqualTo(100m));
            Assert.That(clonedRachunek.Saldo, Is.EqualTo(150m));
        }
    }
}