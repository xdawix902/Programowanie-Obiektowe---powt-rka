using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Z1
{
    public abstract class Ticket : IComparable<Ticket>
    {
        public string matchName;
        public int ticketNumber;

        public Ticket(int ticketNumber, string matchName)   
        {
            this.matchName = matchName;
            this.ticketNumber = ticketNumber;
        }

        public int CompareTo(Ticket? obj)
        {
            if (obj == null || !(obj is Ticket bilet)) return 0;
            return this.ticketNumber.CompareTo(bilet.ticketNumber);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Ticket ticket)) return false;
            return this.ticketNumber == ticket.ticketNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ticketNumber);
        }

        public abstract double GetPrice();

        public override string ToString()
        {
            return $"Bilet numer {ticketNumber} na mecz {matchName}";
        }

        public class TicketMatchNameComparer : IComparer<Ticket>
        {
            public int Compare(Ticket? x, Ticket? y)
            {
                if (x == null || y == null) return 0;
                if (!(x is Ticket pX) || !(y is Ticket pY)) return 0;

                return pX.matchName.CompareTo(pY.matchName);
            }
        }
    }
}
