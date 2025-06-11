namespace Zad2;

public interface IOperacyjny
{
    public void Przelew(decimal kwota, IOperacyjny operacyjny);
    public void Wplata(decimal kwota);
    public void Wyplata(decimal kwota);
}

public enum TypOperacji
{
    Wplata,
    Wyplata,
    Przelew
}

public class OperacjaEventArgs : EventArgs
{
    public decimal kwota;
    public TypOperacji typOperacji;

    public OperacjaEventArgs(TypOperacji typOperacji, decimal kwota)
    {
        this.kwota = kwota;
        this.typOperacji = typOperacji;
    }

    public override string ToString()
    {
        return $"{kwota} {typOperacji}";
    }
}

public class OperacjaReceiverEventArgs : OperacjaEventArgs
{
    public IOperacyjny receiver;

    public OperacjaReceiverEventArgs(decimal kwota, TypOperacji typOperacji, IOperacyjny receiver) : base(typOperacji, kwota)
    {
        this.receiver = receiver;
    }

    public override string ToString()
    {
        return base.ToString() + $" {receiver}";
    }
}

public class Klient : IOperacyjny
{
    string imie;
    string nazwisko;
    private decimal saldo = 0;

    public Klient(string imie, string nazwisko, decimal saldo)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.saldo = saldo;
    }

    public event EventHandler<OperacjaEventArgs> operacjaWykonana;

    public void Wplata(decimal kwota)
    {
        saldo += kwota;
        operacjaWykonana?.Invoke(this, new OperacjaEventArgs(TypOperacji.Wplata, kwota));
    }

    public void Wyplata(decimal kwota)
    {
        if (kwota > saldo)
        {
            throw new ArgumentException("Brak środków");
        }
        saldo -= kwota;
        operacjaWykonana?.Invoke(this, new OperacjaEventArgs(TypOperacji.Wyplata, kwota));
    }

    public void Przelew(decimal kwota, IOperacyjny odbiorca)
    {
        Wyplata(kwota);
        odbiorca.Wplata(kwota);
        operacjaWykonana?.Invoke(this, new OperacjaReceiverEventArgs(kwota, TypOperacji.Przelew, odbiorca));
    }

    public void SetEvenHanler(EventHandler<OperacjaEventArgs> handler)
    {
        operacjaWykonana += handler;
    }

    public override string ToString()
    {
        return $"Klient: {GetHashCode()}";
    }
}

public class Bank
{
    private static Bank instance;
    public static Bank Instance => instance ?? new Bank();
    Dictionary<IOperacyjny, List<OperacjaEventArgs>> historiaTranskacji = new();

    public static void ObslugaOperacji(object sander, OperacjaEventArgs operacja)
    {
        if (sander is IOperacyjny klient)
        {
            Bank inst = instance;
            if (!inst.historiaTranskacji.ContainsKey(klient))
            {
                inst.historiaTranskacji[klient] = new List<OperacjaEventArgs>();
            }
            inst.historiaTranskacji[klient].Add(operacja);
        }
    }

    public void KonfiguracjaHistorii(Klient klient)
    {
        klient.SetEvenHanler(ObslugaOperacji);
    }

    public void WyswietlTransakcje(IOperacyjny klient)
    {
        System.Console.WriteLine($"\nHistoria transkacji klienta {klient}");

        if (historiaTranskacji.TryGetValue(klient, out var lista))
        {
            foreach (var operacja in lista)
            {
                if (operacja is OperacjaReceiverEventArgs o)
                {
                    System.Console.WriteLine($"{o.typOperacji} - {o.kwota} PLN do {o.receiver}");
                }
                else
                {
                    System.Console.WriteLine($"{operacja.typOperacji} - {operacja.kwota} PLN");
                }
            }
        }
        else
        {
            System.Console.WriteLine("Brak transakcji");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
