using System;
using NUnit.Framework;

namespace Z1.Tests
{
    [TestFixture]
    public class TicketTests
    {
        [Test]
        public void Ticket_Equals_SameTicketNumber_ReturnsTrue()
        {
            // Arrange
            var ticket1 = new NormalTicket(1, "Match 1");
            var ticket2 = new NormalTicket(1, "Match 2");

            // Act
            bool result = ticket1.Equals(ticket2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Ticket_Equals_DifferentTicketNumber_ReturnsFalse()
        {
            // Arrange
            var ticket1 = new NormalTicket(1, "Match 1");
            var ticket2 = new NormalTicket(2, "Match 2");

            // Act
            bool result = ticket1.Equals(ticket2);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Ticket_Equals_Null_ReturnsFalse()
        {
            // Arrange
            var ticket = new NormalTicket(1, "Match 1");

            // Act
            bool result = ticket.Equals(null);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Ticket_GetHashCode_SameTicketNumber_ReturnsSameHashCode()
        {
            // Arrange
            var ticket1 = new NormalTicket(1, "Match 1");
            var ticket2 = new NormalTicket(1, "Match 2");

            // Act
            int hashCode1 = ticket1.GetHashCode();
            int hashCode2 = ticket2.GetHashCode();

            // Assert
            Assert.AreEqual(hashCode1, hashCode2);
        }

        [Test]
        public void Ticket_GetHashCode_DifferentTicketNumber_ReturnsDifferentHashCode()
        {
            // Arrange
            var ticket1 = new NormalTicket(1, "Match 1");
            var ticket2 = new NormalTicket(2, "Match 2");

            // Act
            int hashCode1 = ticket1.GetHashCode();
            int hashCode2 = ticket2.GetHashCode();

            // Assert
            Assert.AreNotEqual(hashCode1, hashCode2);
        }

        [Test]
        public void Ticket_ToString_ReturnsCorrectString()
        {
            // Arrange
            var ticket = new NormalTicket(1, "Match 1");

            // Act
            string result = ticket.ToString();

            // Assert
            Assert.AreEqual("Bilet numer 1 na mecz Match 1", result);
        }
    }
}
