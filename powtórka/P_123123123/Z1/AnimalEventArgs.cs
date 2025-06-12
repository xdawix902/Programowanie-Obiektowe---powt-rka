using System;
using System.Collections.Generic;
using System.Text;

namespace Z1
{
    public delegate void AnimalAddedEventHandler(object sender, AnimalEventArgs e);
    public class AnimalEventArgs : EventArgs 
    {
        public Animal Animal { get; }

        public AnimalEventArgs(Animal animal)
        {
            Animal = animal;
        }
    }
}
