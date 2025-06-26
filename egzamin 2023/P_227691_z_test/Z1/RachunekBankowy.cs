using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Z1
{
    public abstract class RachunekBankowy : IComparable<RachunekBankowy>
    {
        string numerRachunku;
        decimal saldo;
        string własciciel;

        public string NumerRachunku { get => numerRachunku; }
        public string Właściciel { get => własciciel; }
        public decimal Saldo { get => saldo; }

        public RachunekBankowy(string numerRachunku, string wlasciciel)
        {
            this.numerRachunku = numerRachunku;
            this.własciciel = wlasciciel;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(RachunekBankowy? other)
        {
            if (other == null) return 0;
            if (!(other is RachunekBankowy aaaa)) return 0;
            return this.własciciel.CompareTo(aaaa.własciciel);
        }

        public override bool Equals(object other)
        {
            if (other == null) return false;
            if (other.GetType() == "".GetType()) return this.numerRachunku == (string)other;

            if (!(other is RachunekBankowy aaaa)) return false;
            return this.numerRachunku.Equals(aaaa.numerRachunku);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(numerRachunku);
        }

        public bool Wpłać(decimal kwota)
        {
            if (kwota < 0)
            {
                OnOperacjaFinansowa?.Invoke(this.Clone() as RachunekBankowy, new OperacjaFinansowaEventArgs(kwota, "Błąd: Próba wpłaty środków mniejszych bądź równych zero."));
                return false;
            }
            saldo += kwota;
            OnOperacjaFinansowa?.Invoke(this.Clone() as RachunekBankowy, new OperacjaFinansowaEventArgs(kwota, "Wpłata środków"));
            return true;
        }

        public bool Wypłać(decimal kwota)
        {
            if (kwota < 0 || kwota > saldo)
            {
                OnOperacjaFinansowa?.Invoke(this.Clone() as RachunekBankowy, new OperacjaFinansowaEventArgs(kwota, "Błąd: Brak wystarczających środków na rachunku."));
                return false;
            }
            saldo -= kwota;
            OnOperacjaFinansowa?.Invoke(this.Clone() as RachunekBankowy, new OperacjaFinansowaEventArgs(kwota, "Wypłata środków"));
            return true;
        }

        public event OperacjaFinansowaEventHandler OnOperacjaFinansowa;

        public class SortowanieSaldaComparer : IComparer<RachunekBankowy>
        {
            public int Compare(RachunekBankowy? x, RachunekBankowy? y)
            {
                if (x == null || y == null) return 0;
                if (!(x is RachunekBankowy pX) || !(y is RachunekBankowy pY)) return 0;
                return pY.saldo.CompareTo(pX.saldo);
            }
        }
    }
}
