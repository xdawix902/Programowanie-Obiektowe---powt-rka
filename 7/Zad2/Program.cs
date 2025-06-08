namespace Zad2;

public abstract class Zwierze{
    string imie;
    decimal waga;
    public decimal Waga{
        get => waga;
    }

    public Zwierze(string imie, decimal waga){
        this.imie = imie;
        this.waga = waga;
    }

    public virtual void PrzedstawSie(){
        System.Console.WriteLine($"Imie: {imie}\nWaga: {waga}");
    }
}

public class Kot : Zwierze{
    int wysokoscSkoku;
    
    public Kot(string imie, decimal waga, int wysokoscSkoku) : base(imie, waga){
        this.wysokoscSkoku = wysokoscSkoku;
    }

    public override void PrzedstawSie()
    {
        base.PrzedstawSie();
        System.Console.WriteLine($"Wysokość skoku: {wysokoscSkoku}");
    }
}

public class Pies : Zwierze
{
    int dlugoscOgona;
    public Pies(string imie, decimal waga, int dlugoscOgona) : base(imie, waga){
        this.dlugoscOgona = dlugoscOgona;
    }

    public new void PrzedstawSie()
    {
        base.PrzedstawSie();
        System.Console.WriteLine($"Dlugosc Ogona: {dlugoscOgona}");   
    }
}

public delegate void ModyfikujZwierze(Zwierze z);

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
