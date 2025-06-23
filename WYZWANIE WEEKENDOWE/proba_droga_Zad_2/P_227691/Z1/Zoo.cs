using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class Zoo
    {
        private List<Animal> animals = new List<Animal>();

        public List<Animal> Animals { get => animals; }
        public Animal this[int index]
        {
            get
            {
                if(index >= 0 && index < animals.Count)
                {
                    return animals[index];
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < animals.Count)
                {
                    animals[index] = value;
                    return;
                }
                throw new IndexOutOfRangeException();
            }
        }
        public Animal this[string name]
        {
            get
            {
                foreach(object ee in animals)
                {
                    if(ee != null && ee is Animal obj && obj.Name == name)
                    {
                        return obj;
                    }
                }
                throw new KeyNotFoundException();
            }
        }

        [Obsolete("Use AddAnimal method instead.")]
        public void Add(Animal animal)
        {
            animals.Add(animal);
        }

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
            OnAnimalAdded(new AnimalEventArgs(animal));
        }

        public void OnAnimalAdded(AnimalEventArgs e)
        {
            AnimalAdded?.Invoke(this, e);
        }

        public event AnimalAddedEventHandler AnimalAdded;
    }
}
