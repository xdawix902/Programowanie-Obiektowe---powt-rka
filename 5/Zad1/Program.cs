using System.Text;

namespace Zad1;

interface IKoszyk{
    public void DodajDoKoszyka(Manga manga);
    public void UsunZKoszyka(Manga manga);
}

class Manga{
    string tytul;
    string autor;
    public decimal cena;

    public Manga(string tytul, string autor, decimal cena){
        this.tytul = tytul;
        this.autor = autor;
        this.cena = cena;
    }

    public override string ToString()
    {
        return $"{tytul} {autor} {cena}";
    }

    public class MangaExecption : Exception{
        public MangaExecption(string message) : base("\t" + message){}
    }
}

class Sklep : IKoszyk{
    Manga[] mangi;
    public static int maksymalnyStanMagazynowy = 100;

    public Sklep(){
        mangi = new Manga[maksymalnyStanMagazynowy];
        mangi[0] = new Manga("Dragon Ball", "miass", 39.99m);
        mangi[1] = new Manga("Demon Slayer","Kaka", 29.99m);
    }

    public void KupMangi(Klient klient){
        System.Console.WriteLine("Mangi zostały zakupione");
        System.Console.WriteLine("Paragon: ");
        decimal cena = 0m;
        if(klient.koszyk.Length == 0) throw new Manga.MangaExecption("Koszyk klienta jest pusty");
        for(int i = 0; i < klient.koszyk.Length; i++){
            if(klient.koszyk[i] != null){
                System.Console.WriteLine(klient.koszyk[i].ToString());
                this.UsunZKoszyka(klient.koszyk[i]);
                cena += klient.koszyk[i].cena;
                klient.UsunZKoszyka(klient.koszyk[i]);
            }
        }
    }

    public void DodajDoKoszyka(Manga manga){
        for(int i = 0; i < mangi.Length; i++){
            if(mangi[i] == null){
                mangi[i] = manga;
                System.Console.WriteLine("Dodano do koszyka");
                break;
            }
        }
        throw new Manga.MangaExecption("Nie znaleziono takiej mangi w sklepie!");
    }

    public void UsunZKoszyka(Manga manga){
        for(int i = 0; i < mangi.Length; i++){
            if(manga.Equals(mangi[i])){
                mangi[i] = null;
                System.Console.WriteLine("Usunięto");
                break;
            }
        }
        throw new Manga.MangaExecption("Nie znaleziono takiej mangi w sklepie");
    }

    public override string ToString()
    {
        StringBuilder opp = new StringBuilder();
        opp.Append("Dostępne mangi w sklepie: ");

        for(int i = 0 ; i < mangi.Length; i++){
            if(mangi[i] != null){
                opp.Append(mangi[i].ToString());
            }
        }
        return opp.ToString();

    }
}

class Klient : IKoszyk{
    public Manga[] koszyk;
    int liczbaMangWKoszyku;
    static int maksymalnyStanKoszyka = 3;
    Sklep sklep;

    public Klient(Sklep sklep){
        koszyk = new Manga[maksymalnyStanKoszyka];
        liczbaMangWKoszyku = 0;
        this.sklep = sklep;
    }

    public void DodajDoKoszyka(Manga manga){
        for(int i = 0; i < koszyk.Length; i++){
            if(koszyk[i] == null){
                koszyk[i] = manga;
                System.Console.WriteLine("Dodano mange do koszyka");
                break;
            }
        }
        throw new Manga.MangaExecption("Koszyk jest już pełny");
    }


    public void UsunZKoszyka(Manga manga){
        for(int i = 0; i < koszyk.Length; i++){
            if(manga.Equals(koszyk[i])){
                koszyk[i] = null;
                System.Console.WriteLine("Usunięto mangę z koszyka");
                break;
            }
        }
        throw new Manga.MangaExecption("Manga nie znajduje się w koszyku klienta");
    }

    public override string ToString()
    {
        StringBuilder ans = new StringBuilder();
        if(koszyk.Length == 0) return "Magni w koszyku klienta: -";
        ans.Append("Mangi w koszyku klienta: ");
        for(int i = 0; i < koszyk.Length; i++){
            ans.Append(koszyk[i].ToString());
        }
        return ans.ToString();

    }

}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
