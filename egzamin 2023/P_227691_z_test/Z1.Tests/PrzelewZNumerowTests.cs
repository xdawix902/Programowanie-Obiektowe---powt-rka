
using NUnit.Framework;
using System.Reflection;

namespace Z1.Tests
{
    [TestFixture]
    class PrzelewZNumerowTests
    {
        [Test]
        [Category("PrzelewZNumerow")]
        public void PrzelewZNumerow_SukcesPrzelewu()
        {
            // Arrange
            var systemBankowy = new SystemBankowy();
            var rachunekZ = new RachunekOsobisty("123456", "Jan Kowalski");
            var rachunekNa = new RachunekOsobisty("654321", "Anna Nowak");

            rachunekZ.Wpłać(500m);
            systemBankowy.RachunkiBankowe.Add(rachunekZ);
            systemBankowy.RachunkiBankowe.Add(rachunekNa);

            // Act
            systemBankowy.Przelew("123456", "654321", 200m);

            // Assert
            Assert.AreEqual(300m, rachunekZ.Saldo);
            Assert.AreEqual(200m, rachunekNa.Saldo);
        }

        [Test]
        [Category("PrzelewZNumerow")]
        public void PrzelewZNumerow_NieudanaProbaPrzelewu_BledneNumery()
        {
            // Arrange
            var systemBankowy = new SystemBankowy();
            var rachunekZ = new RachunekOsobisty("123456", "Jan Kowalski");
            var rachunekNa = new RachunekOsobisty("654321", "Anna Nowak");

            rachunekZ.Wpłać(500m);
            systemBankowy.RachunkiBankowe.Add(rachunekZ);
            systemBankowy.RachunkiBankowe.Add(rachunekNa);

            // Act
            systemBankowy.Przelew("000000", "654321", 200m);

            // Assert
            Assert.AreEqual(500m, rachunekZ.Saldo);
            Assert.AreEqual(0m, rachunekNa.Saldo);
        }
    }
}
