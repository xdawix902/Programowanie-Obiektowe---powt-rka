using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Z1
{
    public abstract class Animal :IAnimal, IComparable<Animal>
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            this.Name = name;
        }

        public int CompareTo(Animal? other)
        {
            if (other == null) return 0;
            if (!(other is Animal zwierz)) return 0;

            return this.Name.CompareTo(zwierz.Name);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Animal zwierz)) return false;

            return this.GetHashCode() == zwierz.GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
        public abstract void MakeSound();

        public class AnimalNameLengthComparer : IComparer<Animal>
        {
            public int Compare(Animal? x,Animal? y)
            {
                if (x == null || y == null) throw new ArgumentNullException();
                if (!(x is Animal pX) || !(y is Animal pY)) return 0;

                return pX.Name.Length.CompareTo(pY.Name.Length);
            }
        }
    }
}
