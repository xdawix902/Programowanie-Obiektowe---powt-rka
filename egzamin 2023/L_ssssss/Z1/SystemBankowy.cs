using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Z1
{
    public class SystemBankowy
    {
        public List<OperacjaFinansowaEventArgs> HistoriaTransakcji = new List<OperacjaFinansowaEventArgs>();
        public List<RachunekBankowy> RachunkiBankowe = new List<RachunekBankowy>();

        public RachunekBankowy this[string s]
        {
            get
            {
                foreach(var e in RachunkiBankowe)
                {
                    if (e != null && e is RachunekBankowy asd && asd.NumerRachunku == s) return asd;
                }
                throw new Exception();
            }
        }
        
        public void DodajRachunek(RachunekBankowy b)
        {
            RachunkiBankowe.Add(b);
        }

        public void Przelew(RachunekBankowy z, RachunekBankowy na, decimal kwota)
        {
            if (z.Wyplac(kwota))
            {
                na.Wpłać(kwota);
            }
        }

        public void Przelew(RachunekBankowy z, string numerNa, decimal kwota)
        {
            RachunekBankowy Na = this[numerNa];
            Przelew(z, Na, kwota);
        }

        public bool UsunRachunekBankowy(RachunekBankowy b)
        {
            foreach (var e in RachunkiBankowe)
            {
                if (e != null && e is RachunekBankowy asd && asd == b)
                {
                    RachunkiBankowe.Remove(asd);
                    return true;
                }
            }
            return false;
        }

    }
}
