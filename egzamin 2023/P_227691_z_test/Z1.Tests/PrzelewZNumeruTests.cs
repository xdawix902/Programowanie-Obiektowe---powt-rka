using NUnit.Framework;
using System.Reflection;

namespace Z1.Tests
{
    [TestFixture]
    class PrzelewZNumeruTests
    {
        [Test]
        [Category("PrzelewZNumeru")]
        public void PrzelewZNumeru_SukcesPrzelewu()
        {
            // Arrange
            var systemBankowy = new SystemBankowy();
            var rachunekZ = new RachunekOsobisty("123456", "Jan Kowalski");
            var rachunekNa = new RachunekOsobisty("654321", "Anna Nowak");

            rachunekZ.Wpłać(500m);
            systemBankowy.RachunkiBankowe.Add(rachunekZ);
            systemBankowy.RachunkiBankowe.Add(rachunekNa);

            // Act
            systemBankowy.Przelew(rachunekZ, "654321", 200m);

            // Assert
            Assert.AreEqual(300m, rachunekZ.Saldo);
            Assert.AreEqual(200m, rachunekNa.Saldo);
        }

        [Test]
        [Category("PrzelewZNumeru")]
        public void PrzelewZNumeru_NieudanaProbaPrzelewu_BlednyNumer()
        {
            // Arrange
            var systemBankowy = new SystemBankowy();
            var rachunekZ = new RachunekOsobisty("123456", "Jan Kowalski");
            var rachunekNa = new RachunekOsobisty("654321", "Anna Nowak");

            rachunekZ.Wpłać(500m);
            systemBankowy.RachunkiBankowe.Add(rachunekZ);
            systemBankowy.RachunkiBankowe.Add(rachunekNa);

            // Act
            systemBankowy.Przelew(rachunekZ, "000000", 200m);

            // Assert
            Assert.AreEqual(500m, rachunekZ.Saldo);
            Assert.AreEqual(0m, rachunekNa.Saldo);
        }
    }
}