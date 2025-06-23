using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class Dog : Animal, IMovable
    {
        public Dog(string name) : base(name) { }

        public static implicit operator Dog(string name) { return new Dog(name); }
        public static implicit operator string(Dog dog) { return dog.Name; }

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
