using System;
using System.Collections.Generic;
using System.Text;

namespace Z1
{
    public class RachunekFirmowy : RachunekBankowy
    {
        private string nazwaFirmy;

        public RachunekFirmowy(string numerRachunku, string wlasciciel, string nazwaFirmy) : base(numerRachunku, wlasciciel)
        {
            this.nazwaFirmy = nazwaFirmy;
        }

        public static explicit operator RachunekOsobisty(RachunekFirmowy rachunek)
        {
            return new RachunekOsobisty(rachunek.NumerRachunku, rachunek.Wlasciciel);
        }

        public static implicit operator RachunekFirmowy(RachunekOsobisty rO)
        {
            return new RachunekFirmowy(rO.NumerRachunku, rO.Wlasciciel, "Domyślna nazwa firmy");
        }
    }
}
