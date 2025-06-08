using System.Text;

namespace Zad2;

class Manga{
    string tytul;
    string autor;
    decimal cena;

    public Manga(string tytul, string autor, decimal cena){
        this.tytul = tytul;
        this.autor = autor;
        this.cena = cena;
    }

    public override string ToString()
    {
        return $"{tytul} {autor} {cena}";
    }
}

class Klient{
    Manga[] koszyk = new Manga[maksymalnyStanKoszyka];
    public static int maksymalnyStanKoszyka = 3;

    public void DodajDoKoszyka(Manga manga){
        for(int i = 0; i < koszyk.Length; i++){
            if(koszyk[i] == null){
                koszyk[i] = manga;
                System.Console.WriteLine("Dodano do koszyka");
                break;
            }
        }
        System.Console.WriteLine("Brak miejsca");
    }

    public void UsunZKoszyka(Manga manga){
        for(int i = 0; i < koszyk.Length; i++){
            if(manga.Equals(koszyk[i])){
                koszyk[i] = null;
                System.Console.WriteLine("Usunieto z koszyka");
                break;
            }
        }
        System.Console.WriteLine("Brak w koszyku tego tytulu");
    }

    public override string ToString()
    {
        StringBuilder ans = new StringBuilder();
        ans.Append("Mangi w koszyku: ");
        if(koszyk.Length == 0) ans.Append(" -");
        else{
            for(int i = 0; i < koszyk.Length; i++){
                if(koszyk[i] != null) ans.Append(koszyk[i].ToString());
            }
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
