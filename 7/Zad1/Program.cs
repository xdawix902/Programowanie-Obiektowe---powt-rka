namespace Zad1;

class CzłonekZespołu : IComparable<CzłonekZespołu>{
    string imie;
    string nazwisko;
    int wiek;

    public CzłonekZespołu(string imie, string nazwisko, int wiek){
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.wiek = wiek;
    }

    public int CompareTo(CzłonekZespołu? other)
    {
        if(other == null) return 1;
        if(!(other is CzłonekZespołu nowy)) throw new Exception("Nie jest CzłonekZespołu");
        return this.wiek.CompareTo(nowy.wiek);
    }

    public class CzłonekZespołuPoNazwiskuComparer : IComparer<CzłonekZespołu>
    {
        public int Compare(CzłonekZespołu? x, CzłonekZespołu? y)
        {
            if(x == null || y == null) return 1;
            if(!(x is CzłonekZespołu pX) || !(y is CzłonekZespołu pY)) throw new Exception("Jeden z nich nie jest klasy CzłonekZepsołu");
            return pX.nazwisko.CompareTo(pY.nazwisko);
        }
    }

    public override string ToString()
    {
        return $"{imie} {nazwisko} {wiek}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        CzłonekZespołu JohnBonham = new CzłonekZespołu("John", "Bonham",32);

        CzłonekZespołu RobertPlant = new CzłonekZespołu("Robert", "Plant", 73);

        CzłonekZespołu JimmyPage = new CzłonekZespołu("Jimmy", "Page", 77);

        CzłonekZespołu JohnPaulJones = new CzłonekZespołu("John Paul", "Jones", 75);

        List<CzłonekZespołu> ledZeppelin = new List<CzłonekZespołu> { JohnBonham, RobertPlant, JimmyPage, JohnPaulJones };

        ledZeppelin.Sort(); // po wieku

        ledZeppelin.Sort(new CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer());


    }
}
