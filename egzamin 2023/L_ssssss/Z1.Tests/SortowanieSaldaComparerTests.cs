using NUnit.Framework;
using BankSystem;
using System.Collections.Generic;

namespace Z1.Tests
{
    [TestFixture]
    public class SortowanieSaldaComparerTests
    {
        private SortowanieSaldaComparer _comparer;

        private class TestRachunekBankowy : RachunekBankowy
        {
            public TestRachunekBankowy(string numerRachunku, string wlasciciel, decimal saldo)
                : base(numerRachunku, wlasciciel)
            {
                // Użyj refleksji do ustawienia salda, ponieważ jest chronione
                // W prawdziwym kodzie, albo saldo byłoby publiczne/internal set, albo byłaby metoda do zainicjowania salda dla testów
                typeof(RachunekBankowy)
                    .GetProperty("Saldo", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                    .SetValue(this, saldo);
            }
        }

        [SetUp]
        public void SetUp()
        {
            _comparer = new SortowanieSaldaComparer();
        }

        [Test]
        public void Compare_XGreaterThanY_ReturnsPositive()
        {
            var rachunekX = new TestRachunekBankowy("1", "X", 200m);
            var rachunekY = new TestRachunekBankowy("2", "Y", 100m);
            Assert.That(_comparer.Compare(rachunekX, rachunekY), Is.GreaterThan(0));
        }

        [Test]
        public void Compare_XLessThanY_ReturnsNegative()
        {
            var rachunekX = new TestRachunekBankowy("1", "X", 50m);
            var rachunekY = new TestRachunekBankowy("2", "Y", 100m);
            Assert.That(_comparer.Compare(rachunekX, rachunekY), Is.LessThan(0));
        }

        [Test]
        public void Compare_XEqualsY_ReturnsZero()
        {
            var rachunekX = new TestRachunekBankowy("1", "X", 100m);
            var rachunekY = new TestRachunekBankowy("2", "Y", 100m);
            Assert.That(_comparer.Compare(rachunekX, rachunekY), Is.EqualTo(0));
        }

        [Test]
        public void Compare_XIsNull_ReturnsNegative()
        {
            var rachunekY = new TestRachunekBankowy("2", "Y", 100m);
            Assert.That(_comparer.Compare(null, rachunekY), Is.LessThan(0));
        }

        [Test]
        public void Compare_YIsNull_ReturnsPositive()
        {
            var rachunekX = new TestRachunekBankowy("1", "X", 100m);
            Assert.That(_comparer.Compare(rachunekX, null), Is.GreaterThan(0));
        }

        [Test]
        public void Compare_BothNull_ReturnsZero()
        {
            Assert.That(_comparer.Compare(null, null), Is.EqualTo(0));
        }

        [Test]
        public void Sort_ListWithVariousSaldos_SortsCorrectly()
        {
            var rachunek1 = new TestRachunekBankowy("A", "OwnerA", 50m);
            var rachunek2 = new TestRachunekBankowy("B", "OwnerB", 200m);
            var rachunek3 = new TestRachunekBankowy("C", "OwnerC", 10m);
            var rachunek4 = new TestRachunekBankowy("D", "OwnerD", 50m); // To samo saldo co rachunek1

            var rachunki = new List<RachunekBankowy> { rachunek1, rachunek2, rachunek3, rachunek4 };
            rachunki.Sort(_comparer);

            Assert.That(rachunki[0], Is.SameAs(rachunek3)); // 10m
            // Rachunki z tym samym saldem (50m) mogą mieć dowolną kolejność między sobą,
            // dlatego testujemy tylko, czy są grupami po saldzie
            Assert.That(rachunki[1].Saldo, Is.EqualTo(50m));
            Assert.That(rachunki[2].Saldo, Is.EqualTo(50m));
            Assert.That(rachunki[3], Is.SameAs(rachunek2)); // 200m
        }
    }
}