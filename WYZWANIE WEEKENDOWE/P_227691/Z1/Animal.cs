using System.Collections;

namespace Z1
{
    public abstract class Animal : IAnimal, IComparable<Animal>
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }

        public int CompareTo(Animal? other)
        {
            if (other == null) return 0;
            if (!(other is Animal zwierz)) return 0;

            return Name.CompareTo(zwierz.Name);

        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Animal zwierz)) return false;

            return Name == zwierz.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public abstract void MakeSound();

        public class AnimalNameLengthComparer : IComparer
        {
            public int Compare(object? x, object? y)
            {
                if (x == null || y == null) throw new ArgumentNullException();
                if (!(x is Animal pX) || !(y is Animal pY)) return 0;

                return pX.Name.Length.CompareTo(pY.Name.Length);
            }
        }
    }
}
