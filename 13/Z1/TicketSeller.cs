using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public delegate void TicketSoldHandler(Ticket ticket);
    public sealed class TicketSeller : ITicketGetter, ITicketSeller
    {
        List<Ticket> ticketSold = new List<Ticket>();

        public string GetTicketsSold()
        {
            string ans = "";

            foreach (var c in ticketSold)
            {
                ans += c.ToString() + $" - cena: {c.GetPrice()} zł \n";
            }
            return ans;
        }

        public string GetTicketsSoldOrdered()
        {
            List<Ticket> kopia = new List<Ticket>(ticketSold);
            kopia.Sort();
            string ans = "";

            foreach(var c in kopia)
            {
                ans += c.ToString() + $" - cena: {c.GetPrice()} zł \n";
            }
            return ans;
        }

        public string GetTicketsSoldOrdered(IComparer<Ticket> comparer)
        {
            List<Ticket> kopia = new List<Ticket>(ticketSold);
            kopia.Sort(comparer);
            string ans = "";

            foreach (var c in kopia)
            {
                ans += c.ToString() + $" - cena: {c.GetPrice()} zł \n";
            }
            return ans;
        }

        public string SellTicket(Ticket ticket, TicketSoldHandler hanlder)
        {
            if (ticketSold.Contains(ticket))
            {
                return "Bilet ten już został sprzedany!";
            }
            ticketSold.Add(ticket);
            hanlder?.Invoke(ticket);
            return $"Bilet numer {ticket.ticketNumber} na mecz {ticket.matchName} został sprzedany.";
        }
    }
}
