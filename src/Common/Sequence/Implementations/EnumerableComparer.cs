using Common.Sequence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Sequence.Implementations
{
    public class EnumerableComparer : IEnumerableComparer
    {
        public bool IsContentTheSame<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            if(collection1 == null || collection2 == null)
            {
                throw new ArgumentNullException();
            }

            if(collection1.Count() != collection2.Count())
            {
                return false;
            }

            return collection1.All(n => collection2.Any(m => n.Equals(m))) && collection2.All(n => collection1.Any(m => n.Equals(m)));
        }
    }
}
