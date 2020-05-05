using Common.Sequence.Implementations;
using Common.Sequence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Sequence.Extensions
{
    public static class IEnumerableExtensions
    {
        private static IEnumerableComparer defaultComparer = new EnumerableComparer();
        public static IEnumerableComparer Comparer { private get; set; } = defaultComparer;
        public static bool IsContentTheSame<T>(this IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            return Comparer.IsContentTheSame(collection1, collection2);
        }

        public static void ResetImplementation()
        {
            Comparer = defaultComparer;
        }
    }
}
