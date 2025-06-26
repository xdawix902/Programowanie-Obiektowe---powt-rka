using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Z1
{
    public class SystemBankowy
    {
        public List<OperacjaFinansowaEventArgs> HistoriaTranskacji = new List<OperacjaFinansowaEventArgs>();
        public List<RachunekBankowy> RachunkiBankowe = new List<RachunekBankowy>();

        public RachunekBankowy this[string s]
        {
            get
            {
                foreach(RachunekBankowy? rachunek in RachunkiBankowe)
                {
                    if (rachunek != null && rachunek.NumerRachunku == s) return rachunek;
                }
                return null;
            }
        }

        public void DodajRachunek(RachunekBankowy b)
        {
            RachunkiBankowe.Add(b);
        }

        public JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects
        };

        public List<RachunekBankowy> Deserializuj(string json)
        {
            return JsonConvert.DeserializeObject<List<RachunekBankowy>>(json, _settings);
        }

        public string Serializuj()
        {
            return JsonConvert.SerializeObject(RachunkiBankowe, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }

        public void Przelew(RachunekBankowy z, RachunekBankowy na, decimal kwota)
        {
            if (z.Wypłać(kwota))
            {
                na.Wpłać(kwota);
                HistoriaTranskacji.Add(new OperacjaFinansowaEventArgs(kwota, "Wpłata środków"));
            }
        }

        public void Przelew(RachunekBankowy z, string numerNa, decimal kwota)
        {
            RachunekBankowy na = this[numerNa];
            if (na == null) return;
            Przelew(z, na, kwota);
        }

        public void Przelew(string numerZ, string numerNa, decimal kwota)
        {
            RachunekBankowy z = this[numerZ];
            RachunekBankowy na = this[numerNa];
            if (z == null || na == null) return;
            Przelew(z, na, kwota);
        }

        public bool UsunRachunek(RachunekBankowy b)
        {
            foreach(var e in RachunkiBankowe)
            {
                if(e == b)
                {
                    RachunkiBankowe.Remove(b);
                    return true;
                }
            }
            return false;
        }

    }
}
