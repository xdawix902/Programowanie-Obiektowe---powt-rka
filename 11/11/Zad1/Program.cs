namespace Zad1
{
    public static class PrzetwarzaniePlikow
    {
        public static void Duplikuj(string path)
        {
            string info_z_pliku = Wczytaj(path);
            string nazwa = Path.GetFileName(path).Split(".")[0];
            string dir = Path.GetDirectoryName(path) + @"\";
            string extenstion = Path.GetExtension(path);

            for(int i = 0; i < int.MaxValue; i++)
            {
                string sciezka = dir + nazwa + "_" + i + extenstion;
                if (!Path.Exists(path))
                {
                    Zapisz(info_z_pliku, sciezka);
                    break;
                }
            }
        }

        public static string Wczytaj(string path)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path,"");
            }
            string ans = File.ReadAllText(path);
            return ans;
        }

        public static void Zapisz(string s,string path)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path,s);
            }
            else
            {
                File.AppendAllText(path, s);
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
