namespace Zad1;

class Geometria{
    public static double Pi = 3.14;
    public static double PierwiastekZTrzech = 1.732050807568877;

    public static double PoleKola(double promien){
        return Pi * promien * promien;
    }
    public static double ObwodKola(double promien){
        return 2 * Pi *  promien;
    }

    public static double PoleProstokata(double a, double b){
        return a * b;
    }

    public static double ObwodProstokata(double a, double b){
        return 2*a + 2*b;
    }

    public static double PoleTrojkataRownobocznego(double a){
        return a*a*PierwiastekZTrzech/4;
    }

    public static double ObwodTrojkataRownobocznego(double a){
        return 3*a;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
