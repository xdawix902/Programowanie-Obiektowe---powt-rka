using System.Collections;
using System.Text;

namespace Zad1;

class Student : IComparable<Student>{
    string imie;
    string nazwisko;
    int numerIndeksu;
    int rokStudiow;

    public Student(string imie, string nazwisko, int numerIndeksu, int rokStudiow){
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.numerIndeksu = numerIndeksu;
        this.rokStudiow = rokStudiow;
    }

    public Student(Student student){
        this.imie = student.imie;
        this.nazwisko = student.nazwisko;
        this.numerIndeksu = student.numerIndeksu;
        this.rokStudiow = student.rokStudiow;
    }

    public override string ToString()
    {
        return $"student {imie} {nazwisko} rok {rokStudiow} indeks numer:{numerIndeksu}";
    }

    public bool Equlas(Student? other){
        if(this != null && other != null){
            return this.numerIndeksu == other.numerIndeksu;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return this.numerIndeksu.GetHashCode();
    }

    public int CompareTo(Student? other)
    {
        if(other == null) return 0;
        return numerIndeksu.CompareTo(other.numerIndeksu);
    }

    public class StudentPoNazwiskuASCComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            if(x == null || y == null) return 0;
            return x.nazwisko.CompareTo(y.nazwisko); 
        }
    }

    public class StudentPoRokStudiowDESCComparer : IComparer<Student>{
        public int Compare(Student? x, Student? y){
            if(x == null || y == null) return 0;
            return y.rokStudiow.CompareTo(x.rokStudiow);
        }
    }
}

public class ZarzadzanieException : Exception{
    public ZarzadzanieException(string message) : base(message){}
}

public delegate void Akcja<T>(T t);

public class Zarzadzanie<T>{
    List<T> zarzadzani;
    public Zarzadzanie(List<T> zarzadzani){
        this.zarzadzani = zarzadzani;
    }

    public int? PodajPozycje(T t){
        if(t == null) throw new ZarzadzanieException("Przekazano do metody PodajPozycje null!");

        int index = zarzadzani.IndexOf(t);
        return index >= 0 ? index : null;
    }
    public void Sortuj(){
        if(zarzadzani == null || zarzadzani.Count == 0) throw new ZarzadzanieException("Nie można posortować pustej lub niezainicjalizowanej listy!"); 
        zarzadzani.Sort(); 
    }

    public void Sortuj<U>(U u) where U : IComparer<T>{
        if(zarzadzani == null || zarzadzani.Count == 0) throw new ZarzadzanieException("Nie można posortować pustej lub niezainicjalizowanej listy!"); 
        zarzadzani.Sort(u); 
    }

    public void Modyfikuj(Akcja<T> akcja){
        if(akcja == null) throw new ZarzadzanieException(nameof(akcja));
        for(int i = 0; i < zarzadzani.Count; i++){
            if(zarzadzani[i] != null) akcja(zarzadzani[i]);
        }
    }

    public override string ToString(){
        StringBuilder ans = new StringBuilder();
        ans.Append("Zarządzane: ");
        for(int i = 0; i < zarzadzani.Count; i++){
            if(zarzadzani[i] != null) ans.Append(zarzadzani[i].ToString());
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
