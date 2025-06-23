using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class AnimalCollection<T> : IEnumerable<T> where T : Animal
    {
        public List<T> animals;
        public AnimalCollection() {
            animals = new List<T>();
        }
        public int Count => animals.Count;

        public void Add(T animal)
        {
            animals.Add(animal);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return animals.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
