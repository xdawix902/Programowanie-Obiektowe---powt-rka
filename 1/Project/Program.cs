namespace Project;

public class Student{
    public string nazwisko;
    public string imie;
    private int nr_albumu;
    private int semestr;
    private int rok_urodzenia;
    private double ocena_z_programowania;

    public Student(string nazwisko, string imie, int nr_albumu, int semestr, int rok_urodzenia, double ocena_z_programowania){
        this.nazwisko = nazwisko;
        this.imie = imie;
        this.nr_albumu = nr_albumu;
        this.semestr = semestr;
        this.rok_urodzenia = rok_urodzenia;
        this.ocena_z_programowania = ocena_z_programowania;
    }
    
    public Student(string imie, string nazwisko):this(imie ,nazwisko, 1000, 1, 2000, 2.0){
    }

    public string WyswietlInformacje(){
        return $"Imie: {this.imie}\nNazwisko: {this.nazwisko}\nNr_albumu: {this.nr_albumu}\nSemestr: {this.semestr}\nRok Urodzenia: {this.rok_urodzenia}\nOcena z Programowania: {this.ocena_z_programowania}";
    }
    public int ZwrocWiek(){
        return 2025-rok_urodzenia;
    }

    private string zwrocStatystykiStudiowania(){
        return $"{this.nr_albumu} {this.semestr}";
    }

    public string StudentiJegoStatystyki(){
        return this.zwrocStatystykiStudiowania + $" {this.rok_urodzenia}";
    }

    public double ZwrocOcene(){
        return this.ocena_z_programowania;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student x = new Student("Filipek","Dawid", 227691, 2, 2005, 1);
        System.Console.WriteLine(x.WyswietlInformacje());
    }
}
