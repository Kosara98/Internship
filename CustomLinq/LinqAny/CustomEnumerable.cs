using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomLinq
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

        public static bool CustomAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (!predicate(item))
                    return false;
            }
            return true;
        }

        public static T CustomFirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            IList<T> list = source as IList<T>;
            if(list.Count > 0)
            {
                foreach (var item in list)
                {
                    if (predicate(item))
                        return item;
                }
            }
            return default(T);
        }

        public static T CustomFirstOrDefault<T>(this IEnumerable<T> source)
        {
            IList<T> list = source as IList<T>;
            if (list.Count == 0)
                return default(T);
            else
                return list[0];
        }

        public static T CustomFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            IList<T> list = source as IList<T>;
            foreach (var item in list)
            {
                if (predicate(item))
                    return item;
            }
            throw new InvalidOperationException();
        }
        
        public static T CustomFirst<T>(this IEnumerable<T> source)
        {
            IList<T> list = source as IList<T>;
            if (list.Count == 0)
                throw new InvalidOperationException();
            return list[0];
        }

        public static IEnumerable<T> CustomReverse<T>(this IEnumerable<T> source)
        {
            IList<T> list = source as IList<T>;
            for (int i = list.Count - 1; i >= 0; i--)
                yield return list[i];
        }

        public static bool CustomContains<T> (this IEnumerable<T> source, T value)
        {
            IList<T> list = source as IList<T>;
            foreach (var item in list)
            {
                if (item.Equals(value))
                    return true;
            }
            return false;
        }

        public static IEnumerable<T> CustomConcat<T> (this IEnumerable<T> first, IEnumerable<T> second)
        {
            foreach (var item in first)
                yield return item;

            foreach (var item in second)
                yield return item;
        }
    }
}
