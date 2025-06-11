using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    interface ITicketGetter
    {
        string GetTicketsSold();
        string GetTicketsSoldOrdered();
        string GetTicketsSoldOrdered(IComparer<Ticket> comparer);
    }
}
