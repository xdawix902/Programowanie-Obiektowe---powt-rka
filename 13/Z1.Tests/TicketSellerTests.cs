using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Z1.Tests
{
    [TestFixture]
    internal class TicketSellerTests
    {
        [Test]
        public void SellTicket_NewTicket_TicketSoldHandlerCalled()
        {
            // Arrange
            var ticketSeller = new TicketSeller();
            bool handlerCalled = false;
            TicketSoldHandler handler = (ticket) => { handlerCalled = true; };

            // Act
            Ticket ticket = new NormalTicket(1, "Match 1");
            var returned = ticketSeller.SellTicket(ticket, handler);

            // Assert
            Assert.AreEqual($"Bilet numer 1 na mecz Match 1 został sprzedany.", returned);
            Assert.IsTrue(handlerCalled);
        }

        [Test]
        public void SellTicket_ExistingTicket_ReturnsTicketAlreadySold()
        {
            // Arrange
            var ticketSeller = new TicketSeller();
            var ticket = new NormalTicket(1, "Match 1");
            ticketSeller.SellTicket(ticket, (t) => { });

            // Act
            string result = ticketSeller.SellTicket(ticket, (t) => { });

            // Assert
            Assert.AreEqual("Bilet ten już został sprzedany!", result);
        }

        [Test]
        public void GetTicketsSold_ReturnsCorrectTicketsSold()
        {
            // Arrange
            var ticketSeller = new TicketSeller();
            ticketSeller.SellTicket(new NormalTicket(1, "Match 1"), (t) => { });
            ticketSeller.SellTicket(new VIPTicket(2, "Match 2"), (t) => { });

            // Act
            string result = ticketSeller.GetTicketsSold();

            // Assert
            StringAssert.Contains("Bilet numer 1 na mecz Match 1 - cena: 50 zł", result);
            StringAssert.Contains("Bilet numer 2 na mecz Match 2 - cena: 150 zł", result);
        }

        [Test]
        public void GetTicketsSoldOrdered_ReturnsTicketsSortedByTicketNumber()
        {
            // Arrange
            var ticketSeller = new TicketSeller();
            ticketSeller.SellTicket(new NormalTicket(2, "Match 2"), (t) => { });
            ticketSeller.SellTicket(new NormalTicket(1, "Match 1"), (t) => { });

            // Act
            string result = ticketSeller.GetTicketsSoldOrdered();

            // Assert
            StringAssert.Contains("Bilet numer 1 na mecz Match 1 - cena: 50 zł", result);
            StringAssert.Contains("Bilet numer 2 na mecz Match 2 - cena: 50 zł", result);
        }

        [Test]
        public void GetTicketsSoldOrdered_CustomComparer_ReturnsTicketsSortedByMatchName()
        {
            // Arrange
            var ticketSeller = new TicketSeller();
            ticketSeller.SellTicket(new NormalTicket(2, "Match B"), (t) => { });
            ticketSeller.SellTicket(new NormalTicket(1, "Match A"), (t) => { });

            // Act
            string result = ticketSeller.GetTicketsSoldOrdered(new Ticket.TicketMatchNameComparer());

            // Assert
            StringAssert.Contains("Bilet numer 1 na mecz Match A - cena: 50 zł", result);
            StringAssert.Contains("Bilet numer 2 na mecz Match B - cena: 50 zł", result);
        }
    }
}
