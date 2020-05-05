using Common.Sequence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Sequence.Implementations
{
    public class RandomElementPicker : IRandomElementPicker
    {
        public T PickRandom<T>(IEnumerable<T> collection)
        {
            Func<T, bool> func = (x) => { return true; };
            return this.PickRandom(collection, func);
        }

        public T PickRandom<T>(IEnumerable<T> collection, Func<T, bool> func)
        {
            IEnumerable<T> filteredCollection = collection.Where(func).ToList();

            if(!filteredCollection.Any())
            {
                if(typeof(T) == typeof(string))
                {
                    return (T)Convert.ChangeType(string.Empty, typeof(T));
                }

                return default;
            }

            int collectionCount = filteredCollection.Count();

            Random random = new Random();
            int drawnIndex = random.Next(collectionCount);

            return filteredCollection.Skip(drawnIndex).First();
        }
    }
}
