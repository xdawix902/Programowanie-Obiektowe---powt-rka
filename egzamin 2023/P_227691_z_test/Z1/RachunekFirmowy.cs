using System;
using System.Collections.Generic;
using System.Text;

namespace Z1
{
    public class RachunekFirmowy : RachunekBankowy
    {
        string nazwaFirmy;

        public string NazwaFirmy { get => nazwaFirmy; }

        public RachunekFirmowy(string numerRachunku, string własciciel, string nazwaFirmy) : base(numerRachunku, własciciel)
        {
            this.nazwaFirmy = nazwaFirmy;
        }

        public static explicit operator RachunekOsobisty(RachunekFirmowy rachunek)
        {
            return new RachunekOsobisty(rachunek.NumerRachunku, rachunek.Właściciel);
        }

        public static implicit operator RachunekFirmowy(string rachunek)
        {
            string[] wartosci = rachunek.Split(',');
            if (wartosci.Length < 3) return null;
            return new RachunekFirmowy(wartosci[0], wartosci[1], wartosci[2]);
        }
    }
}
