using System;
using System.Collections.Generic;
using System.Text;

namespace Z1
{
    public sealed class VIPTicket : Ticket
    {
        public VIPTicket(int ticketNumber, string matchName) : base(ticketNumber, matchName) { }

        public override double GetPrice()
        {
            return 150.00;
        }
    }
}
