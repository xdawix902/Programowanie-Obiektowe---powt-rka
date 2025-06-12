using System;
using System.Collections.Generic;
using System.Text;
using static Z1.Ticket;

namespace Z1
{
    public delegate void TicketSoldHandler(Ticket ticket);
    public sealed class TicketSeller : ITicketGetter, ITicketSeller
    {
        List<Ticket> ticketsSold = new List<Ticket>();

        public string GetTicketsSold()
        {
            StringBuilder ans = new StringBuilder();
            foreach(var c in ticketsSold)
            {
                ans.AppendLine(c.ToString() + $" - cena: {c.GetPrice()} zł \n");
            }
            return ans.ToString();
        }

        public string GetTicketsSoldOrdered()
        {
            StringBuilder ans = new StringBuilder();
            List<Ticket> kopia = new List<Ticket>(ticketsSold);
            kopia.Sort();
            foreach (var c in kopia)
            {
                ans.AppendLine(c.ToString() + $" - cena: {c.GetPrice()} zł \n");
            }
            return ans.ToString();
        }

        public string GetTicketsSoldOrdered(Ticket.TicketMatchNameComparer comparer)
        {
            StringBuilder ans = new StringBuilder();
            List<Ticket> kopia = new List<Ticket>(ticketsSold);
            kopia.Sort(comparer);
            foreach (var c in kopia)
            {
                ans.AppendLine(c.ToString()+ $" - cena: {c.GetPrice()} zł \n");
            }
            return ans.ToString();
        }

        public string SellTicket(Ticket ticket, TicketSoldHandler handler)
        {
            if (ticketsSold.Contains(ticket))
            {
                return "Bilet ten już został sprzedany!";
            }
            else{
                ticketsSold.Add(ticket);
                handler?.Invoke(ticket);
                return ticket.ToString() + $" został sprzedany.";
            }
        }
    }
}
