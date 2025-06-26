﻿
using NUnit.Framework;
using System.Reflection;
using System;

namespace Z1.Tests
{
    [TestFixture]
    class ExplicitImplicitTests
    {
        [Test]
        [Category("Explicit/Implicit")]
        public void OperatorExplicit_RachunekFirmowyNaRachunekOsobisty_KonwersjaPoprawna()
        {
            // Arrange
            RachunekFirmowy rachunekFirmowy = new RachunekFirmowy("123456789", "Nazwa Firmy", "Firma Sp. z o.o.");

            // Act
            RachunekOsobisty rachunekOsobisty = (RachunekOsobisty)rachunekFirmowy;

            // Assert
            Assert.AreEqual("123456789", rachunekOsobisty.NumerRachunku);
            Assert.AreEqual("Nazwa Firmy", rachunekOsobisty.Właściciel);
        }

        [Test]
        [Category("Explicit/Implicit")]
        public void OperatorExplicit_RachunekFirmowyNaRachunekOsobisty_KonwersjaPoprawna2()
        {
            // Arrange
            RachunekFirmowy rachunekFirmowy = new RachunekFirmowy("123456332", "Nazwa Firmy", "Firma Sp. z o.o.");

            // Act
            RachunekOsobisty rachunekOsobisty = (RachunekOsobisty)rachunekFirmowy;

            // Assert
            Assert.AreEqual("123456332", rachunekOsobisty.NumerRachunku);
            Assert.AreEqual("Nazwa Firmy", rachunekOsobisty.Właściciel);
        }

        [Test]
        [Category("Explicit/Implicit")]
        public void OperatorExplicit_RachunekFirmowyNaRachunekOsobisty_KonwersjaPoprawna3()
        {
            // Arrange
            RachunekFirmowy rachunekFirmowy = new RachunekFirmowy("321456332", "Nazwa Firmy 2", "Firma 2 Sp. z o.o.");

            // Act
            RachunekOsobisty rachunekOsobisty = (RachunekOsobisty)rachunekFirmowy;

            // Assert
            Assert.AreEqual("321456332", rachunekOsobisty.NumerRachunku);
            Assert.AreEqual("Nazwa Firmy 2", rachunekOsobisty.Właściciel);
        }
        
        [Test]
        [Category("Explicit/Implicit")]
        public void OperatorImplicit_RachunekOsobistyNaRachunekFirmowy_KonwersjaPoprawna()
        {
            // Act
            RachunekFirmowy rachunekFirmowy = "987654321,Jan Kowalski,Januszex Sp. z.o.o.";

            // Assert
            Assert.AreEqual("987654321", rachunekFirmowy.NumerRachunku);
            Assert.AreEqual("Jan Kowalski", rachunekFirmowy.Właściciel);
            Assert.AreEqual("Januszex Sp. z.o.o.", rachunekFirmowy.NazwaFirmy);
        }

        [Test]
        [Category("Explicit/Implicit")]
        public void OperatorImplicit_RachunekOsobistyNaRachunekFirmowy_KonwersjaNiePoprawna()
        {
            // Act
            RachunekFirmowy rachunekFirmowy = "987654321,Jan Kowalski";

            // Assert
            Assert.IsNull(rachunekFirmowy);
        }
    }
}