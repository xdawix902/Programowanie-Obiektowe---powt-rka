namespace Zad2;

class KontoBankowe{
    private int numerKonta;
    private string imieWlasciciela;
    private decimal saldo;

    protected decimal Saldo{
        get => saldo;
    }

    public KontoBankowe(int numerKonta, string imieWlasciciela, decimal saldo){
        this.numerKonta = numerKonta;
        this.imieWlasciciela = imieWlasciciela;
        this.saldo = saldo;
    }

    public KontoBankowe(int numerKonta, string imieWlasciciela) : this(numerKonta, imieWlasciciela,0){}

    public virtual void Wplac(decimal kwota){
        saldo+=kwota;
    }

    public bool Wyplac(decimal kwota){
        if(kwota > saldo) return false;
        saldo -= kwota;
        return true;
    }

    public virtual string ZwrocInformacje(){
        return $"NumerKonta: {numerKonta}\nImieWlasciciela: {imieWlasciciela}\nSaldo: {saldo}";
    }
}

class KontoOszczednosciowe : KontoBankowe{
    private decimal stopaProcentowa;

    public KontoOszczednosciowe(int numerKonta, string imieWlasciciela, decimal saldo, decimal stopaProcentowa) : base(numerKonta, imieWlasciciela, saldo){
        this.stopaProcentowa = stopaProcentowa;
    }
    public KontoOszczednosciowe(int numerKonta, string imieWlasciciela, decimal stopaProcentowa) : base(numerKonta, imieWlasciciela){
        this.stopaProcentowa = stopaProcentowa;
    }
    public KontoOszczednosciowe(int numerKonta, string imieWlasciciela) : this(numerKonta, imieWlasciciela,0){}

    public override void Wplac(decimal kwota)
    {
        base.Wplac(kwota*(1+stopaProcentowa));
    }

    public override string ZwrocInformacje()
    {
        return base.ZwrocInformacje() + $"\nStopaProcentowa: {stopaProcentowa}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
