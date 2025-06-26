
using NUnit.Framework;
using System.Reflection;

namespace Z1.Tests
{
    [TestFixture]
    class PrzelewBezposredniTests
    {
        [Test]
        [Category("PrzelewBezposredni")]
        public void PrzelewBezposredni_SukcesPrzelewu()
        {
            // Arrange
            var systemBankowy = new SystemBankowy();
            var rachunekZ = new RachunekOsobisty("123456", "Jan Kowalski");
            var rachunekNa = new RachunekOsobisty("654321", "Anna Nowak");

            rachunekZ.Wpłać(500m);
            systemBankowy.RachunkiBankowe.Add(rachunekZ);
            systemBankowy.RachunkiBankowe.Add(rachunekNa);

            // Act
            systemBankowy.Przelew(rachunekZ, rachunekNa, 200m);

            // Assert
            Assert.AreEqual(300m, rachunekZ.Saldo);
            Assert.AreEqual(200m, rachunekNa.Saldo);
        }

        [Test]
        [Category("PrzelewBezposredni")]
        public void PrzelewBezposredni_NieudanaProbaPrzelewu_ZaMaloSrodkow()
        {
            // Arrange
            var systemBankowy = new SystemBankowy();
            var rachunekZ = new RachunekOsobisty("123456", "Jan Kowalski");
            var rachunekNa = new RachunekOsobisty("654321", "Anna Nowak");

            rachunekZ.Wpłać(100m);
            systemBankowy.RachunkiBankowe.Add(rachunekZ);
            systemBankowy.RachunkiBankowe.Add(rachunekNa);

            // Act
            systemBankowy.Przelew(rachunekZ, rachunekNa, 200m);

            // Assert
            Assert.AreEqual(100m, rachunekZ.Saldo);
            Assert.AreEqual(0m, rachunekNa.Saldo);
        }
    }
}
