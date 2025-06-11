using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Z1.Tests
{
    [TestFixture]
    public class TicketMatchNameComparerTests
    {
        [Test]
        public void TicketMatchNameComparer_Compare_SameMatchName_ReturnsZero()
        {
            // Arrange
            var comparer = new Ticket.TicketMatchNameComparer();
            var ticket1 = new NormalTicket(1, "Match 1");
            var ticket2 = new NormalTicket(2, "Match 1");

            // Act
            int result = comparer.Compare(ticket1, ticket2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TicketMatchNameComparer_Compare_DifferentMatchName_ReturnsNonZero()
        {
            // Arrange
            var comparer = new Ticket.TicketMatchNameComparer();
            var ticket1 = new NormalTicket(1, "Match 1");
            var ticket2 = new NormalTicket(2, "Match 2");

            // Act
            int result = comparer.Compare(ticket1, ticket2);

            // Assert
            Assert.AreNotEqual(0, result);
        }

        [Test]
        public void TicketMatchNameComparer_Compare_NullTicket_ReturnsZero()
        {
            // Arrange
            var comparer = new Ticket.TicketMatchNameComparer();
            NormalTicket ticket = null;
            var otherTicket = new NormalTicket(1, "Match 1");

            // Act
            int result = comparer.Compare(ticket, otherTicket);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TicketMatchNameComparer_Compare_NullOtherTicket_ReturnsZero()
        {
            // Arrange
            var comparer = new Ticket.TicketMatchNameComparer();
            var ticket = new NormalTicket(1, "Match 1");
            NormalTicket otherTicket = null;

            // Act
            int result = comparer.Compare(ticket, otherTicket);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TicketMatchNameComparer_Compare_BothTicketsNull_ReturnsZero()
        {
            // Arrange
            var comparer = new Ticket.TicketMatchNameComparer();
            NormalTicket ticket = null;
            NormalTicket otherTicket = null;

            // Act
            int result = comparer.Compare(ticket, otherTicket);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
