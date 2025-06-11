using System.Collections;
using System.Text;

namespace Zad1;

class ListaNaSterydach<T> : List<T>
{
    public override string ToString()
    {
        StringBuilder opp = new StringBuilder();
        Enumerator e = this.GetEnumerator();

        while (e.MoveNext())
        {
            opp.AppendLine(e.Current?.ToString() ?? null);
        }
        return opp.ToString();
    }
}

class Osoby : IEnumerable
{
    ListaNaSterydach<Osoba> listaOsob;

    public Osoby(ListaNaSterydach<Osoba> listaOsob)
    {
        this.listaOsob = listaOsob;
    }

    public IEnumerator GetEnumerator()
    {
        return new OsobyEnumerator(listaOsob);
    }


    public class OsobyEnumerator : IEnumerator
    {
        ListaNaSterydach<Osoba> items;
        int index = -1;

        public OsobyEnumerator(ListaNaSterydach<Osoba> items)
        {
            this.items = items;
        }

        public object Current => items[index];

        public bool MoveNext()
        {
            index += 2;
            return index < items.Count;
        }

        public void Reset()
        {
            index = -1;
        }

    }
}

class Osoba
{
    string imie;
    string nazwisko;
    int? wiek;

    public Osoba(string imie, string nazwisko, int wiek)
    {
        this.imie = imie;
        this.wiek = wiek;
        this.nazwisko = nazwisko;
    }

    public Osoba(string imie, string nazwisko)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.wiek = null;
    }

    public object this[int i]
    {
        get
        {
            switch (i)
            {
                case 0: return this.imie;
                case 1: return this.nazwisko;
                case 2: return wiek?.ToString() ?? "";
                default: throw new ArgumentOutOfRangeException("Nie ma takiej wartości");
            }
        }
    }

    public override string ToString()
    {
        if (wiek != null)
        {
            return $"{imie} {nazwisko} {wiek}";
        }
        return $"{imie} {nazwisko}";
    }

    public static explicit operator string(Osoba c)
    {
        return c.ToString();
    }

    public static implicit operator Osoba(string c)
    {
        string[] oooo = c.Split(" ");
        if (oooo.Length < 2)
        {
            throw new Exception("Za mało argumentów");
        }
        else if (oooo.Length == 2)
        {
            return new Osoba(oooo[0], oooo[1]);
        }
        else if (oooo.Length == 3)
        {
            int age;
            if (int.TryParse(oooo[2], out age))
            {
                return new Osoba(oooo[0], oooo[1], age);
            }
        }
        throw new ArgumentException("Niepoprawny format imienia, nazwiska i wieku. Oczekiwany format: 'Imię Nazwisko Wiek'. Wiek w postaci liczby!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Osoba osoba1 = new Osoba("Jan", "Kowalski", 25);
        Osoba osoba2 = new Osoba("Anna", "Nowak", 30);
        Osoba osoba3 = new Osoba("Piotr", "Zalewski", 22);
        
        Console.WriteLine("Test enumeratora wbudowanego w List<T>:");
        ListaNaSterydach<Osoba> listaOsob = new ListaNaSterydach<Osoba> { osoba1, osoba2, osoba3 };
        Console.WriteLine(listaOsob);
        Console.WriteLine("=====================================");
        
        Console.WriteLine("Test enumeratora osoby:");
        Osoby osoby = new Osoby(listaOsob);
        foreach (var item in osoby)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("=====================================");
        
        string s1 = "Mariusz Lewandowski";
        string s2 = "Robert Lewandowski 15";
        
        Osoba o1 = s1;
        Console.WriteLine(o1);
        
        Osoba o2 = s2;
        Console.WriteLine(o2);
        
        string s3 = (string)osoba1;
        Console.WriteLine(s3);
        
        Console.WriteLine("\tExcel:");
        string[,] tabelkaExcela = new string[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                tabelkaExcela[i, j] = (string)listaOsob[i][j];
            }
        }
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(tabelkaExcela[i,j] + " ");
            }
            Console.WriteLine();
        }
        
        Osoba o3 = "Sławomir Peszko 0.7";
        Console.WriteLine(o3);
    }
}
