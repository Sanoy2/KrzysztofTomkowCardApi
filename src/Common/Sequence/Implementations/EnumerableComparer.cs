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
            if (collection1 == null || collection2 == null)
            {
                throw new ArgumentNullException();
            }

            return collection1.FirstOrDefault().Equals(collection2.FirstOrDefault());
        }
    }
}
