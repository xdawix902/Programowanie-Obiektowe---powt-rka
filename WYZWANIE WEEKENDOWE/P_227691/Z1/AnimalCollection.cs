using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class AnimalCollection<T> : IEnumerable<T>
    {
        public List<T> animals = new List<T>();
        int count = 0;
        public int Count { get => count; }

        public void Add(T animal)
        {
            animals.Add(animal);
            count++;
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
