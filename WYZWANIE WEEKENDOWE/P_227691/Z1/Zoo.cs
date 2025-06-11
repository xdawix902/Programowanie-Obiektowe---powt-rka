using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class Zoo
    {
        public event AnimalAddedEventHandler AnimalAdded;

        List<Animal> animals = new List<Animal>();
        public List<Animal> Animals { get => animals; }


        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
            OnAnimalAdded(new AnimalEventArgs(animal));
        }

        protected virtual void OnAnimalAdded(AnimalEventArgs e)
        {
            AnimalAdded?.Invoke(this,e);
        }
    }
}
