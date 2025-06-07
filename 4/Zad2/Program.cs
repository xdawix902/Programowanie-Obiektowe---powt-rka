namespace Zad2;

interface IWypozyczalny{
    public void Wypozycz(Klient klient);
    public bool SprawdzDostepnosc();
}

abstract class Media : IWypozyczalny{
    private string tytul;
    private string autor;
    private int rokWydania;
    private decimal cena;

    public Media(string tytul, string autor, int rokWydania, decimal cena){
        this.tytul = tytul;
        this.autor = autor;
        this.rokWydania = rokWydania;
        this.cena = cena;
    }

    public void Wypozycz(Klient klient){
        Console.WriteLine("Wypożyczono " + tytul);
    }
    
    public virtual bool SprawdzDostepnosc(){return true;}
}

class Ksiazka : Media{
    private int liczbaStron;

    public Ksiazka(string tytul, string autor, int rokWydania, decimal cena, int liczbaStron) : base(tytul,autor,rokWydania,cena){
        this.liczbaStron = liczbaStron;
    }
}
class Ebook : Media{
    private int rozmiar;

    public Ebook(string tytul, string autor, int rokWydania, decimal cena, int rozmiar)
        :base(tytul, autor, rokWydania, cena){
            this.rozmiar = rozmiar;
        }
}

class Czasopismo : Media{
    public Czasopismo(string tytul, string autor, int rokWydania, decimal cena)
        :base(tytul, autor, rokWydania, cena) {}
    
    public override bool SprawdzDostepnosc(){
        return false;
    }
}

public class Klient{
    private string imie;
    private string nazwisko;
    Media[] wypozyczoneMedia = new Media[maksymalnaLiczbaWypozyczen];
    public static int maksymalnaLiczbaWypozyczen = 3;

    public Klient(string imie, string nazwisko){
        this.imie = imie;
        this.nazwisko = nazwisko;
    }

    public int IloscWypozyczonychMediow{
        get => policzMedia();
    }

    private int policzMedia(){
        int i = 0;
        foreach(Media? m in wypozyczoneMedia){
            if(m != null) i++;
        }
        return i;
    }

    public void DodajMedia(Media media){
        for(int i=0; i < wypozyczoneMedia.Length; i++){
            if(wypozyczoneMedia[i] == null){
                wypozyczoneMedia[i] = media;
                break;
            }
        }
    }
}

public class Wypozyczalnia : IWypozyczalny
    {
        private Media[] media = new Media[] {
            new Ksiazka("W pustyni i w puszczy", "Henryk Sienkiewicz", 1911, 29.99M, 320),
            new Ksiazka("Pan Tadeusz", "Adam Mickiewicz", 1834, 19.99M, 240),
            new Ksiazka("Zbrodnia i kara", "Fiodor Dostojewski", 1866, 24.99M,  450),
            new Ebook("Metro 2033", "Dmitrij Głuchowski", 2005, 14.99M, 1024),
            new Ebook("Wiedźmin", "Andrzej Sapkowski", 1990, 12.99M, 80),
            new Ebook("Gra o tron", "George R.R. Martin", 1996, 18.99M, 120),
            new Czasopismo("National Geographic", "", 2005, 8.99M),
            new Czasopismo("Wiedza i Życie", "", 2005, 6.99M)};


        public void Wypozycz(Klient klient)
        {
           if(klient.IloscWypozyczonychMediow >= 3){
                Console.WriteLine("Niestety, nie możesz wypożyczyć kolejnych mediów! Oddaj najpierw wypożyczone media!"); return;}
            
            Console.WriteLine("Dostępne media:");
            for(int i = 0; i< media.Length; i++)
            {
                if (media[i] != null)
                {
                    Console.WriteLine((i+1) + ": " + media[i].GetType().Name + " - \""+ media[i].Tytul + "\" - status: " + media[i].SprawdzDostepnosc());
                }
            }
            Console.WriteLine("Wybierz media do wypożyczenia:");
            int wybor = Convert.ToInt32(Console.ReadLine());

            if (wybor >= 1 && wybor <= media.Length)
            {
                var medium = media[wybor - 1];
                if (medium != null && medium.SprawdzDostepnosc())
                {
                    medium.Wypozycz(klient);
                    media[wybor - 1] = null; // Ustawiamy referencję na null, żeby wypożyczalnia nie miała już dostępu do wypożyczonego medium
                }
                else
                {
                    Console.WriteLine("Nie można wypożyczyć tego media.");
                }
            }
            else
            {
                Console.WriteLine("Nie ma takiego media.");
            }
        }

        public bool SprawdzDostepnosc()
        {
            //Sprawdzamy czy istnieje conajmniej jedno medium dostępne do wypozyczenia
            bool jestDostepne = false;
            foreach (var medium in media)
            {
                if (medium != null && medium.SprawdzDostepnosc())
                {
                    jestDostepne = true;
                    break;
                }
            }
            return jestDostepne;
        }
    }


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
