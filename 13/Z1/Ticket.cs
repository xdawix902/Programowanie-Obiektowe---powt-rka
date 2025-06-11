namespace Z1
{
    public abstract class Ticket : IComparable<Ticket>
{
        public string matchName;
        public int ticketNumber;

        public Ticket(string matchName, int ticketNumber)
        {
            this.matchName = matchName;
            this.ticketNumber = ticketNumber;
        }

        public int CompareTo(Ticket? other)
        {
            if (other == null) return 0;
            if (!(other is Ticket drugi))
            {
                throw new ArgumentException("Obiekt nie jest typem Ticket");
            }
            return ticketNumber.CompareTo(drugi.ticketNumber);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if(!(obj is Ticket drugi))
            {
                throw new ArgumentException();
            }
            return ticketNumber == drugi.ticketNumber;
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
                if (!(x is Ticket pX) || !(y is Ticket pY)) return 0;  //tu może być ArgumentException
                return pX.matchName.CompareTo(pY.matchName);
            }
        }

    }
}
