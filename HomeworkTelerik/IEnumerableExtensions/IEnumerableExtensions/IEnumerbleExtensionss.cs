using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableExtensions
{
    public static class IEnumerbleExtensionss
    {
        public static T Sum<T>(this IEnumerable<T> numbers)
        {
            T result = (dynamic)0;
            CheckingIfTheListIsEmpty(numbers);

            foreach (var item in numbers)
                result += (dynamic)item;

            return result;
        }
        
        public static double Product<T>(this IEnumerable<T> numbers)
        {
            CheckingIfTheListIsEmpty(numbers);
            double result = 1;

            foreach (var item in numbers)
                result *= (dynamic)item;

            return result;
        }

        public static T Min<T>(this IEnumerable<T> numbers)
        {
            CheckingIfTheListIsEmpty(numbers);
            T result = numbers.First();

            foreach (var item in numbers)
                if (result > (dynamic)item)
                    result = item;

            return result;
        }

        public static T Max<T>(this IEnumerable<T> numbers)
        {
            CheckingIfTheListIsEmpty(numbers);
            T result = (dynamic)(-1);

            foreach (var item in numbers)
                if (result < (dynamic)item)
                    result = item;

            return result;
        }

        public static double Average<T>(this IEnumerable<T> numbers)
        {
            CheckingIfTheListIsEmpty(numbers);

            double result = (dynamic)numbers.Sum();
            result = result / numbers.Count();
            return result;
        }

        private static void CheckingIfTheListIsEmpty<T>(IEnumerable<T> numbers)
        {
            if (numbers.Count() == 0)
                throw new ArgumentException("The list/array is empty");
        }
    }
}
