using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqAny
{
    public static class CustomEnumerable
    {
        public static bool CustomAny<T>(this IEnumerable<T> source)
        {
            IEnumerator<T> enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
                return true;
            return false;
        }

        public static bool CustomAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    return true;
            }
            return false;
        } 

    }
}
