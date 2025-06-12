using System;
using System.Collections.Generic;
using System.Text;

namespace Z1
{
    public interface ITicketGetter
    {
        public string GetTicketsSold();

        public string GetTicketsSoldOrdered();

        public string GetTicketsSoldOrdered(Ticket.TicketMatchNameComparer comparer);
    }
}
