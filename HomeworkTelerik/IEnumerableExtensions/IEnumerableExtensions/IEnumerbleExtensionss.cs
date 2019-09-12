using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableExtensions
{
    public static class IEnumerbleExtensionss
    {
        public static int Sum(this IEnumerable<int> numbers)
        {
            int result = 0;

            foreach (var item in numbers)
                result += item;

            return result;
        }
        
        public static double Product(this IEnumerable<int> numbers)
        {
            double result = 0;

            foreach (var item in numbers)
            {
                if (result == 0)
                    result = 1;
                result *= item;
            }
            return result;
        }

        public static int Min(this IEnumerable<int> numbers)
        {
            CheckingIfTheListIsEmpty(numbers);
            int result = numbers.First();

            foreach (var item in numbers)
                if (result > item)
                    result = item;

            return result;
        }

        public static int Max(this IEnumerable<int> numbers)
        {
            CheckingIfTheListIsEmpty(numbers);
            int result = numbers.First();

            foreach (var item in numbers)
                if (result < item)
                    result = item;

            return result;
        }

        public static double Average(this IEnumerable<int> numbers)
        {
            CheckingIfTheListIsEmpty(numbers);

            double result = numbers.Sum();
            result = result / numbers.Count();
            return 0;
        }

        private static void CheckingIfTheListIsEmpty<T>(IEnumerable<T> numbers)
        {
            if (numbers.Count() == 0)
                throw new ArgumentException("The list/array is empty");
        }
    }
}
