namespace zad2;

class GraKomputerowa{
    public string nazwa;
    public string wydawca;
    private int ocena;
    private int rokWydania;
    private int liczbaGraczy;

    public GraKomputerowa(string nazwa, string wydawca, int ocena, int rokWydania, int liczbaGraczy){
        this.nazwa = nazwa;
        this.wydawca = wydawca;
        this.ocena = ocena;
        this.rokWydania = rokWydania;
        this.liczbaGraczy = liczbaGraczy;
    }
    public GraKomputerowa(string nazwa, string wydawca) :this(nazwa, wydawca, 0, 2000, 1){}

    public string WyswieltInformacje(){
        return $"Nazwa: {this.nazwa}\nWydawca: {this.wydawca}\nOcena: {this.ocena}\nRok Wydania: {this.rokWydania}\nLiczba Graczy: {this.liczbaGraczy}";
    }

    public int ZwrocLiczbeGraczy(){
        return liczbaGraczy;
    }

    private string zwróćOcenaIRokWydania(){
        return $"{ocena} {rokWydania}";
    }

    public string GraIKomponenty(){
        return this.zwróćOcenaIRokWydania() + $" {this.liczbaGraczy}";
    }
    
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
