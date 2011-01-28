using System.Collections.Generic;
using System.Linq;

namespace Prova.Extensions
{
    public static class ForIEnumerable
    {
        public static bool HasCountOf<T>(this IEnumerable<T> enumerable, int count)
        {
            if (enumerable.IsNothing())
            {
                return false;
            }
            return enumerable.Count() == count;
        }

        public static bool AreUnique<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable.IsNothing())
            {
                return true;
            }
            return enumerable.Distinct().Count() == enumerable.Count();
        }
    }
}