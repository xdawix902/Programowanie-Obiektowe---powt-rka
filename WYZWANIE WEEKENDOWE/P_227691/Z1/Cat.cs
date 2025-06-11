using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
        }
        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }
}
