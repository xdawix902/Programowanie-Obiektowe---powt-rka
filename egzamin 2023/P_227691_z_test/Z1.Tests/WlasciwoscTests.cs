using NUnit.Framework;
using System.Reflection;

namespace Z1.Tests
{
    [TestFixture]
    public class WlasciwoscTests
    {
        [Test]
        [Category("Właściwości")]
        public void NumerRachunku_Getter_DziałaPoprawnie()
        {
            // Arrange
            string numerRachunku = "123456789";
            RachunekBankowy rachunek = new RachunekOsobisty(numerRachunku, "Jan Kowalski");

            // Act
            string retrievedNumerRachunku = rachunek.NumerRachunku;

            // Assert
            Assert.AreEqual(numerRachunku, retrievedNumerRachunku);
        }

        [Test]
        [Category("Właściwości")]
        public void Wlasciciel_Getter_DziałaPoprawnie()
        {
            // Arrange
            string właściciel = "Jan Kowalski";
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", właściciel);

            // Act
            string retrievedWłaściciel = rachunek.Właściciel;

            // Assert
            Assert.AreEqual(właściciel, retrievedWłaściciel);
        }

        [Test]
        [Category("Właściwości")]
        public void NumerRachunku_Setter_NieJestDostepny()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(RachunekBankowy).GetProperty("NumerRachunku");
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");

            // Act
            bool isSetterAvailable = propertyInfo.GetSetMethod(true) != null;

            // Assert
            Assert.IsFalse(isSetterAvailable);
        }

        [Test]
        [Category("Właściwości")]
        public void Wlasciciel_Setter_NieJestDostepny()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(RachunekBankowy).GetProperty("Właściciel");
            RachunekBankowy rachunek = new RachunekOsobisty("123456789", "Jan Kowalski");

            // Act
            bool isSetterAvailable = propertyInfo.GetSetMethod(true) != null;

            // Assert
            Assert.IsFalse(isSetterAvailable);
        }
    }
}