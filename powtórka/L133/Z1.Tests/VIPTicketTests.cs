using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Z1.Tests
{
    internal class VIPTicketTests
    {
        [Test]
        public void VIPTicket_GetPrice_ReturnsCorrectPrice()
        {
            // Arrange
            var ticket = new VIPTicket(1, "VIP Match");

            // Act
            double price = ticket.GetPrice();

            // Assert
            Assert.AreEqual(150.00, price);
        }

        [Test]
        public void VIPTicket_IsSealed()
        {
            // Arrange
            Type vipTicketType = typeof(VIPTicket);

            // Act

            // Assert
            Assert.IsTrue(vipTicketType.IsSealed);
        }
    }
}
