using NUnit.Framework;
using BankSystem;
using System.Reflection; // Potrzebne do testowania pól prywatnych

namespace Z1.Tests
{
    [TestFixture]
    public class RefleksjaTests
    {
        // Klasa testowa z prywatnymi polami
        private class KlasaZPolamiPrywatnymi
        {
            private string _prywatnePoleString = "Wartość string";
            private int _prywatnePoleInt = 123;
            private bool _prywatnePoleBool = true;

            public string PublicznePole = "Wartość publiczna";
        }

        [Test]
        public void OdczytajPolaPrywatne_ReturnsCorrectPrivateFieldValues()
        {
            var obj = new KlasaZPolamiPrywatnymi();
            string result = Refleksja.OdczytajPolaPrywatne(obj);

            Assert.That(result, Contains.Substring("Pola prywatne klasy KlasaZPolamiPrywatnymi:"));
            Assert.That(result, Contains.Substring("- Nazwa: _prywatnePoleString, Wartość: Wartość string"));
            Assert.That(result, Contains.Substring("- Nazwa: _prywatnePoleInt, Wartość: 123"));
            Assert.That(result, Contains.Substring("- Nazwa: _prywatnePoleBool, Wartość: True"));
            Assert.That(result, Does.Not.Contain("PublicznePole")); // Publiczne pola nie powinny być odczytywane
        }

        [Test]
        public void OdczytajPolaPrywatne_NoPrivateFields_ReturnsCorrectMessage()
        {
            var obj = new object(); // System.Object nie ma prywatnych pól instancji
            string result = Refleksja.OdczytajPolaPrywatne(obj);

            Assert.That(result, Contains.Substring("Pola prywatne klasy Object:"));
            Assert.That(result, Contains.Substring("Brak pól prywatnych."));
        }

        [Test]
        public void OdczytajPolaPrywatne_NullObject_ReturnsCorrectMessage()
        {
            string result = Refleksja.OdczytajPolaPrywatne<object>(null);
            Assert.That(result, Is.EqualTo("Obiekt jest nullem."));
        }
    }
}