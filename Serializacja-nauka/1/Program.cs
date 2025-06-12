using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Newtonsoft.Json;

namespace _1
{
    class Bohater
    {
        [JsonProperty("Imie: ")]
        string imie;
        [JsonProperty("Moc: ")]
        string moc;
        [JsonProperty("Życie: ")]
        int hp;

        public Bohater(string imie, string moc, int hp)
        {
            this.imie = imie;
            this.moc = moc;
            this.hp = hp;
        }

        public override string ToString()
        {
            return $"{imie} {moc} {hp}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bohater a = new Bohater("Spiderman", "cos", 12);
            Console.WriteLine(a.ToString());

            string player_serialized = JsonConvert.SerializeObject(a);
            File.WriteAllText(@"C:\Users\dawid\Desktop\ProgObiek\Programowanie-Obiektowe---powt-rka\Serializacja-nauka\serializacja.json", player_serialized);

            string p = File.ReadAllText(@"C:\Users\dawid\Desktop\ProgObiek\Programowanie-Obiektowe---powt-rka\Serializacja-nauka\serializacja.json");

            Bohater r = JsonConvert.DeserializeObject<Bohater>(p);
            Console.WriteLine(r.ToString());


        }
    }
}
