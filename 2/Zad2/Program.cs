namespace Zad2;

class Student{
    public string imie;
    public string nazwisko;
    public string numerAlbumu;
    private GlosZaGraCounterStrike counterStrike;
    private GlosZaGraLeagueOfLegends leagueOfLegends;

    public Student(string imie, string nazwisko, string numerAlbumu){
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.numerAlbumu = numerAlbumu;
    }

    public void ZaglosujZaGraLeagueOfLegends(){
        if(counterStrike != null || leagueOfLegends != null){
            System.Console.WriteLine("Już oddałeś głos");
        }
        else{
            leagueOfLegends = new GlosZaGraLeagueOfLegends();
            System.Console.WriteLine("Oddałeś głos na lola");
        }
    }

    public void ZaglosujZaCounterStrike(){
        if(counterStrike != null || leagueOfLegends != null){
            System.Console.WriteLine("Już oddałeś głoś");
        }
        else{
            counterStrike = new GlosZaGraCounterStrike();
            System.Console.WriteLine("Oddałeś głos na cs'ka");
        }
    }
}

class GlosZaGraLeagueOfLegends {
    private static uint ileGlosow;
    public GlosZaGraLeagueOfLegends (){
        ileGlosow++;
    }
    public static uint ZwrocIloscGlosow(){
        return ileGlosow;
    }
}

class GlosZaGraCounterStrike{
    private static uint ileGlosow;
    public GlosZaGraCounterStrike(){
        ileGlosow++;
    }
    public static uint ZwrocIloscGlosow(){
        return ileGlosow;
    }
}
class Program
{
    static void Main(string[] args)
    {
        
    }
}
