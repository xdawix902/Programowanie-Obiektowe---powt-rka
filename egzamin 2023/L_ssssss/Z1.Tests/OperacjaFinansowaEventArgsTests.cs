using NUnit.Framework;
using BankSystem;
using System;

namespace Z1.Tests
{
    [TestFixture]
    public class OperacjaFinansowaEventArgsTests
    {
        [Test]
        public void Constructor_ValidArguments_SetsPropertiesCorrectly()
        {
            var args = new OperacjaFinansowaEventArgs(150.50m, "Testowy opis operacji");
            Assert.That(args.Kwota, Is.EqualTo(150.50m));
            Assert.That(args.Opis, Is.EqualTo("Testowy opis operacji"));
        }
    }
}