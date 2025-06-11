namespace Z1
{
    public class CzłonekZespołu : IComparable
    {
        string imie;
        string nazwisko;
        public int wiek;

        public CzłonekZespołu(string imie, string nazwisko, int wiek)
        {
            if (wiek <= 0) throw new ArgumentOutOfRangeException();
            if (imie == null || nazwisko == null) throw new ArgumentException();
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.wiek = wiek;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            if (!(obj is CzłonekZespołu other))
                throw new Exception("");
            return wiek.CompareTo(other.wiek);
        }

        public class CzłonekZespołuPoNazwiskuComparer : IComparer<CzłonekZespołu>
        {
            public int Compare(CzłonekZespołu x, CzłonekZespołu y)
            {
                if (x == null || y == null) return 1;
                if (!(x is CzłonekZespołu pX) || !(y is CzłonekZespołu pY))
                    throw new Exception("");
                return pX.nazwisko.CompareTo(pY.nazwisko);
            }
        }
        public override string ToString()
        {
            return $"{imie} {nazwisko} {wiek}";
        }
    }
}
