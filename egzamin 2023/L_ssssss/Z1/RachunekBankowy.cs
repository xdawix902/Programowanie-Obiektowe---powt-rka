using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Z1
{
    public abstract class RachunekBankowy : IComparable<RachunekBankowy>, ICloneable
    {
        private string numerRachunku;
        private decimal saldo;
        private string wlasciciel;

        public string NumerRachunku { get => numerRachunku;}
        public string Wlasciciel { get => wlasciciel;}

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(RachunekBankowy? other)
        {
            if (other == null) return 0;
            if (!(other is RachunekBankowy eeee)) return 0;
            return this.numerRachunku.CompareTo(eeee.numerRachunku);
        }

        public override bool Equals(object other)
        {
            if (other == null) return false;
            if (!(other is RachunekBankowy eeee)) return false;
            return this.numerRachunku == eeee.numerRachunku;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(numerRachunku);
        }

        public RachunekBankowy(string numerRachunku, string wlasciciel)
        {
            this.numerRachunku = numerRachunku;
            this.wlasciciel = wlasciciel;
        }

        public bool Wpłać(decimal kwota)
        {
            if(kwota >= 0)
            {
                saldo += kwota;
                return true;
            }
            return false;
        }

        public bool Wyplac(decimal kwota)
        {
            if(kwota < 0 || kwota > saldo)
            {
                return false;
            }
            saldo -= kwota;
            return true;
        }

        public event OperacjaFinansowaEventHandler OnOperacjaFinansowa;

        public class SortowanieSaldaComperer : IComparer<RachunekBankowy>
        {
            public int Compare(RachunekBankowy? x, RachunekBankowy? y)
            {
                if (x == null || y == null) return 0;
                if (!(x is RachunekBankowy pX) || !(y is RachunekBankowy pY)) return 0;
                return pX.saldo.CompareTo(pY.saldo);
            }
        }
    }
}
