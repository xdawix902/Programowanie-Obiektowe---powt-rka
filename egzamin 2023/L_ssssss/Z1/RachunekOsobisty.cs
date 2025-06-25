using System;
using System.Collections.Generic;
using System.Text;

namespace Z1
{
    public class RachunekOsobisty : RachunekBankowy
    {
        public RachunekOsobisty(string numerRachunku, string wlasciciel) : base(numerRachunku, wlasciciel)
        {
        }
    }
}
