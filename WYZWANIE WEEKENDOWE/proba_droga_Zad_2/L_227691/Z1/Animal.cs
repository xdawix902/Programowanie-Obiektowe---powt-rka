using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (!(other is Animal aaa)) return 0;
            return Name.CompareTo(aaa.Name);
        }

        public override bool Equals(object? other)
        {
            if (other == null) return false;
            if (!(other is Animal aaa)) return false;
            return Name.Equals(aaa.Name);
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

        public static string Serialize(Animal other)
        {
            return JsonConvert.SerializeObject(other, Formatting.None, _settings);
        }

        public class AnimalNameLengthComparer : IComparer<Animal>
        {
            public int Compare(Animal? x, Animal? y)
            {
                if (x == null || y == null) throw new ArgumentNullException();
                if(!(x is Animal pX) || !(y is Animal pY)) return 0;
                return pX.Name.Length.CompareTo(pY.Name.Length);
            }
        }
    }
}
