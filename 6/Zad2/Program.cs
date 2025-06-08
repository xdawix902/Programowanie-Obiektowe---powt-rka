using System.Text;

namespace Zad2;

public enum StronaKonfilktu{
    REPUBLIKA,
    IMPERIUM
}

public delegate string Wybierz(PostacStarWars c);

public class PostacStarWars{
    string imie;
    string gatunek;
    public string plec;
    Planeta planetaMacierzysta;
    StronaKonfilktu stronaKonfliktu;

    public PostacStarWars(string imie, string gatunek, string plec, Planeta planetaMacierzysta, StronaKonfilktu stronaKonfliktu){
        this.imie = imie;
        this.gatunek = gatunek;
        this.plec = plec;
        this.planetaMacierzysta = planetaMacierzysta;
        this.stronaKonfliktu = stronaKonfliktu;
    }

    public PostacStarWars(PostacStarWars postac) :this(postac.imie, postac.gatunek, postac.plec, postac.planetaMacierzysta, postac.stronaKonfliktu){}

    public override string ToString(){
        return $"Imie: {imie}, Gatunek: {gatunek}, Planeta Macierzysta: {planetaMacierzysta}, Plec: {plec}, Strona Konfilktu: {stronaKonfliktu}";
    }
}

public class Planeta{
    string nazwa;
    uint? liczbaKsiezycow;

    public Planeta(string nazwa, uint? liczbaKsiezycow){
        this.nazwa = nazwa;
        this.liczbaKsiezycow = liczbaKsiezycow;
    }

    public Planeta(Planeta planeta) : this(planeta.nazwa, planeta.liczbaKsiezycow){}

    public override string ToString(){
        return $"Planeta {nazwa}, księżyce: {liczbaKsiezycow}";
    }
}

public class PostacieStarWars{
    List<PostacStarWars> postacie = new List<PostacStarWars>();

    [Obsolete("Ta metoda jest przestarzała! Użyj ZwrocPostaciPo(Wybierz wybierz, string wartosc)",false)]
    public List<PostacStarWars> ZwrocPostaciPoPlci(string plec){
        List<PostacStarWars> aaa = new List<PostacStarWars>();

        foreach(PostacStarWars b in postacie){
            if(b.plec == plec) aaa.Add(new PostacStarWars(b));
        }
        return aaa;
    }

    public List<PostacStarWars> ZwrocPostaciPo(Wybierz wybierz, string wartosc){
        List<PostacStarWars> aaa = new List<PostacStarWars>();

        foreach(PostacStarWars b in postacie){
            string wartoscPola = wybierz(b);

            if(wartoscPola == wartosc) aaa.Add(new PostacStarWars(b));
        }
        return aaa;
    }

    public override string ToString(){
        StringBuilder aa = new StringBuilder();
        foreach(var b in postacie){
            aa.Append(b.ToString());
        }
        return aa.ToString();
    }

    public void Dodaj(PostacStarWars postac){
        postacie.Add(postac);
    }
}

public static class ListExtension<T>{
    public static string ZwrocInfoOLiscie(List<T> lista){
        if(lista == null) return "Lista jest null";
        if(lista.Count == 0) return "Lista jest pusta";

        StringBuilder aa = new StringBuilder();
        aa.AppendLine($"Lista obiektów typu {typeof(T).Name} : ");

        foreach(var item in lista){
            if(item != null) aa.AppendLine(item.ToString());
        }
        return aa.ToString();

    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
