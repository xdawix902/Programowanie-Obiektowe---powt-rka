namespace Zad1;

abstract class Zwierze{
    string nazwa;
    float waga;
    float wysokosc;

    public Zwierze(string nazwa, float waga, float wysokosc){
        this.nazwa = nazwa;
        this.waga = waga;
        this.wysokosc = wysokosc;
    }
    
    public virtual void Jedz(float wartosc){
        waga += wartosc;
    }
    public abstract string PoruszajSie();
    public override string ToString()
    {
        return $"{nazwa} {waga} {wysokosc}";
    }
}

class Kot : Zwierze{
    private int liczbaWyskokow;
    private int liczbaNawrotow;

    public Kot(string nazwa, float waga, float wysokosc, int liczbaWyskokow, int liczbaNawrotow) : base(nazwa,waga,wysokosc){
        this.liczbaWyskokow = liczbaWyskokow;
        this.liczbaNawrotow = liczbaNawrotow;
    }

    public override void Jedz(float wartosc)
    {
        base.Jedz(wartosc);
        System.Console.WriteLine("Kot zjadl");
    }

    public override string PoruszajSie()
    {
        return "Kot porusza sie";
    }

    public override string ToString()
    {
        return base.ToString() + $" {liczbaWyskokow} {liczbaNawrotow}";
    }
}

class BazaZwierzat{
    Zwierze[] zwierzeta = new Zwierze[5];

    public void DodajZwierze(Zwierze zwierze){
        int i = 0;
        while(i < 5){
            if(zwierzeta[i] != null){
                zwierzeta[i] = zwierze;
                System.Console.WriteLine("Dodano zwierze");
                break;
            }
        }
        System.Console.WriteLine("Nie ma miejsca");
    }

    public void UsunZwierze(Zwierze zwierze){
        int i = 0;
        while(i < 5){
            if(zwierzeta[i] == zwierze){
                zwierzeta[i] = null;
                System.Console.WriteLine("Usunieto zwierze");
                break;
            }
        }
        System.Console.WriteLine("Nie ma tego zwierzeta");
    }

    private string ZwrocZwierzeta(){
        string ans = "";
        foreach(Zwierze? e in zwierzeta){
            if(e == null) continue;
            ans += (e.ToString()) + "\n";
        }
        return ans;
    }

    public void WszystkieZwierzetaJedza(float wartosc){
        foreach(Zwierze? e in zwierzeta){
            if(e == null) continue;
            e.Jedz(wartosc);
        }
    }
    public void WszystkieZwierzetaPoruszajaSie(){
        foreach(Zwierze? e in zwierzeta){
            if(e == null) continue;
            e.PoruszajSie();
        }
    }

    public override string ToString(){
        string ans = "";
        foreach(Zwierze? e in zwierzeta){
            if(e == null) continue;
            ans += e.ToString();
        }
        return ans;
    }

}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
