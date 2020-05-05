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

        private static IRandomElementPicker defaultRandomPicker = new RandomElementPicker();
        public static IRandomElementPicker RandomPicker { private get; set; } = defaultRandomPicker;

        public static bool IsContentTheSame<T>(this IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            return Comparer.IsContentTheSame(collection1, collection2);
        }

        public static T PickRandom<T>(this IEnumerable<T> collection)
        {
            return RandomPicker.PickRandom(collection);
        }

        public static T PickRandom<T>(this IEnumerable<T> collection, Func<T, bool> func)
        {
            return RandomPicker.PickRandom(collection, func);
        }

        public static void ResetImplementation()
        {
            Comparer = defaultComparer;
            RandomPicker = defaultRandomPicker;
        }
    }
}
