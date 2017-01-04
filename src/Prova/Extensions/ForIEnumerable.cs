using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Prova.Extensions
{
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public static class ForIEnumerable
    {
        public static bool HasCountOf<T>(this IEnumerable<T> enumerable, int count)
        {
            if (enumerable.IsNothing()) return false;
            return enumerable.Count() == count;
        }

        public static bool AreUnique<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable.IsNothing()) return true;

            var list = enumerable as IList<T> ?? enumerable.ToList();
            return list.Distinct().Count() == list.Count();
        }
    }
}
