using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Sequence.Interfaces
{
    public interface IRandomElementPicker
    {
        T PickRandom<T>(IEnumerable<T> collection);
        T PickRandom<T>(IEnumerable<T> collection, Func<T, bool> func);
    }
}
