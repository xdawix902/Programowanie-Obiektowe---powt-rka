using System;
using System.Collections.Generic;
using System.Text;

namespace Z1
{
    public interface ITicketSeller
    {
        public string SellTicket(Ticket ticket, TicketSoldHandler handler); //zmień typ zwracany
    }
}
