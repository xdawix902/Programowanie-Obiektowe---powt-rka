using Newtonsoft.Json;

namespace Z1
{
    public abstract class Animal : IComparable<Animal>, IAnimal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            this.Name = name;
        }

        public int CompareTo(Animal? obj)
        {
            if(obj == null || !(obj is Animal aa)) return 0;
            return this.Name.CompareTo(aa.Name);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Animal aa)) return false;
            return aa.Name == (this.Name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name);
        }

        public abstract void MakeSound();

        public class AnimalNameLengthComparer : IComparer<Animal>
        {
            public int Compare(Animal? x, Animal? y)
            {
                if (x == null || y == null) throw new ArgumentNullException();
                if (!(x is Animal pX)) return 0;
                if (!(y is Animal pY)) return 0;
                return pX.Name.Length.CompareTo(pY.Name.Length);
            }
        }

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
    }
}
