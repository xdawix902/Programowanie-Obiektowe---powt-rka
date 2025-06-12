using System;
using System.Collections.Generic;
using System.Text;

namespace Z1
{
    public class Dog : Animal, IMovable
    {
        public Dog(string name) : base(name) { }

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
