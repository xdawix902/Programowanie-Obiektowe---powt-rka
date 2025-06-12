using System;
using System.Collections.Generic;
using System.Text;

namespace Z1
{
    public sealed class NormalTicket : Ticket
    {
        public override double GetPrice()
        {
            return 50.00;
        }

        public NormalTicket(int number, string match) : base(number, match) { }
    }
}
