using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class Cat : Animal
    {
        public Cat(string Name) : base(Name) { }

        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }
}
