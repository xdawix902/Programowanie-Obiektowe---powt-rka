using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public delegate void AnimalAddedEventHandler(object sender, AnimalEventArgs e);

    public class AnimalEventArgs
    {
        public Animal Animal { get; }

        public AnimalEventArgs(Animal animal)
        {
            Animal = animal;
        }
    }
}
