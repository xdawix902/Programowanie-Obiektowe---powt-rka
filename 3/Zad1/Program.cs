namespace Zad1;

class Samochod{
    private int rokProdukcji;
    private string marka;
    private int predkoscMax;
    protected int predkosc;
    protected int PredkoscMax{
        get => predkoscMax;
    }

    public Samochod(int rokProdukcji, string marka, int predkoscMax, int predkosc){
        this.rokProdukcji = rokProdukcji;
        this.marka = marka;
        this.predkoscMax = predkoscMax;
        this.predkosc = predkosc;
    }

    public Samochod(int rokProdukcji, string marka, int predkoscMax) : this(rokProdukcji, marka,predkoscMax, 0){}

    public string ZwrocInformacje(){
        return $"{marka} {rokProdukcji} Vmax = {predkoscMax} V = {predkosc}";
    }
}

class SamochodKierowany : Samochod{
    private string peselKierowcy;
    public SamochodKierowany(int rokProdukcji, string marka, int predkoscMax, int predkosc, string peselKierowcy) : base(rokProdukcji, marka,predkoscMax,predkosc){
        this.peselKierowcy = peselKierowcy;
    }

    public SamochodKierowany(int rokProdukcji, string marka, int predkoscMax, string peselKierowcy) : base(rokProdukcji, marka, predkoscMax){
        this.peselKierowcy = peselKierowcy;
    }

    public new string ZwrocInformacje(){
        return base.ZwrocInformacje() + $" {peselKierowcy}";
    }

    public void Przyspiesz(int oile){
        if(predkosc + oile <= PredkoscMax){
            predkosc+= oile;
        }
        else{
            predkosc = PredkoscMax;
        }
    }

    public void Zwolnij(int oile){
        predkosc -= oile;
        if(predkosc < 0) predkosc = 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
