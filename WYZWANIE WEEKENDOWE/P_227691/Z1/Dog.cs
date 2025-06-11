using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class Dog :Animal, IMovable
    {
        public Dog(string Name) : base(Name) { }

        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }

        public void Move()
        {
            Console.WriteLine("Dog is running!");
        }
    }
}
