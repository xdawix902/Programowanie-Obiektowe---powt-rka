using System;
using System.Collections.Generic;
using System.Text;

namespace Z1
{
    public delegate void OperacjaFinansowaEventHandler(object sender, OperacjaFinansowaEventArgs e);

    public class OperacjaFinansowaEventArgs : EventArgs
    {
        public decimal Kwota { get; }
        public string Opis { get; }

        public OperacjaFinansowaEventArgs(decimal kwota, string opis)
        {
            Kwota = kwota;
            Opis = opis;
        }
    }
}
