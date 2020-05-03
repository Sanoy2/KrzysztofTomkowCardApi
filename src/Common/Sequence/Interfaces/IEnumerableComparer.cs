using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Sequence.Interfaces
{
    public interface IEnumerableComparer
    {
        bool IsContentTheSame<T>(IEnumerable<T> collection1, IEnumerable<T> collection2);
    }
}
