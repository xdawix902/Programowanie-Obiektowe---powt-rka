using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Newtonsoft.Json;

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
            return Name.CompareTo(other.Name);
        }

        public override bool Equals(object? other)
        {
            if (other == null) return false;
            if (!(other is Animal zwierz)) return false;
            return Name == zwierz.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public abstract void MakeSound();

        public static JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects
        };

        public static Animal Deserialize(string jsonString)
        {
            return JsonConvert.DeserializeObject<Animal>(jsonString, _settings);
        }

        public static string Serialize(Animal animal)
        {
            return JsonConvert.SerializeObject(animal, Formatting.None, _settings);
        }

        public class AnimalNameLengthComparer : IComparer<Animal>
        {
            public int Compare(Animal? x, Animal? y)
            {
                if (x == null || y == null) throw new ArgumentNullException();
                if (!(x is Animal pX) || !(y is Animal pY)) return 0;
                return pX.Name.Length.CompareTo(pY.Name.Length);
            }
        }
    }
}
