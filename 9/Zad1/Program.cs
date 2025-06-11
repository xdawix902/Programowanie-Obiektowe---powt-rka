namespace Zad1;

interface IZwierzecy
{
    public string WydajDzwiek();
}

class Zoo<T> where T : IZwierzecy
{
    List<T> zwierzeta = new List<T>();
    public List<T> Zwierzeta
    {
        get => zwierzeta;
    }

    public void DodajZwierzeta<U>(U animal) where U : T
    {
        zwierzeta.Add(animal);
    }

    public T GetZwierzeAt(int index)
    {
        return zwierzeta[index];
    }

    public void KarmZwierzeta(IEnumerable<T> zwierzeta)
    {
        foreach (var c in zwierzeta)
        {
            System.Console.WriteLine($"Karmimy: {c.WydajDzwiek()}");
        }
    }

    public void UsunZwierzeta<U>(U animal) where U : T
    {
        zwierzeta.Remove(animal);
    }

}

class Ryba : IZwierzecy
{
    public string WydajDzwiek()
    {
        return "Bul buk";
    }
}

class Pies : IZwierzecy
{
    public string WydajDzwiek()
    {
        return "Hau hau";
    }
}

class Kot : IZwierzecy
{
    public string WydajDzwiek()
    {
        return "Miau miau";
    }
}

class Program
{
    static void Main(string[] args)
    {
        var zoo = new Zoo<IZwierzecy>();

        zoo.DodajZwierzeta(new Pies());

        zoo.DodajZwierzeta(new Kot());

        zoo.DodajZwierzeta(new Ryba());

        zoo.KarmZwierzeta(zoo.Zwierzeta); // Hau hau!, Miau miau!, Bul bul!Console.WriteLine("Hello, World!");
    }
}
