namespace Zad2
{
    public class Osoba
    {
        string Imie;
        int Wiek;
        string Nazwisko { get; set; }

        public Osoba(string imie, string nazwisko, int wiek)
        {
            Imie = imie;
            Wiek = wiek;
            Nazwisko = nazwisko;
        }

        public void UstawWiek(int wiek)
        {
            Wiek = wiek;
        }

        public string ZwrocPelneImie()
        {
            return $"{Imie} {Nazwisko}";
        }

        public int ZwrocWiek()
        {
            return Wiek;
        }
    }

    public class Samochod
    {
        string Marka;
        int RokProdukcji;
        string Model { get; set; }

        public Samochod(string marka,string model, int rokProdukcji)
        {
            Marka = marka;
            RokProdukcji = rokProdukcji;
            Model = model;
        }

        public void UstawRokProdukcji(int rokProdukcji)
        {
            RokProdukcji = rokProdukcji;
        }

        public string ZwrocMarkeModel()
        {
            return $"{Marka} {Model}";
        }

        public int ZwrocRokProdukcji()
        {
            return RokProdukcji;
        }
    }

    public static class ObjectReflector
    {
        public static List<string> GetFieldName(object obj)
        {
            List<string> ans = new List<string>();
            var x = obj.GetType().GetFields();

            foreach(var c in x)
            {
                ans.Append(c.Name);
            }
            return ans;
        }

        public static List<string> GetMethods(object obj)
        {
            List<string> ans = new List<string>();
            var x = obj.GetType().GetMethods();
            
            foreach(var c in x)
            {
                ans.Append(c.Name);
            }
            return ans;
        }

        public static List<string> GetPropertyNames(object obj)
        {
            List<string> ans = new List<string>();
            var x = obj.GetType().GetProperties();

            foreach(var c in x)
            {
                ans.Append(c.Name);
            }
            return ans;
        }
    }

    public static class ListHelper
    {
        public static void Wyswietl(this List<string> list)
        {
            foreach(var c in list)
            {
                Console.WriteLine(c);
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
