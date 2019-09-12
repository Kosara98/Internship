using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableExtensions
{
    public static class IEnumerbleExtensionss
    {
        public static double Sum(this IEnumerable<double> numbers) 
        {
            double result = 0;

            if (numbers.IsNumericType())
            {
                foreach (var item in numbers)
                    result += item;
                return result;
            }
            else
                throw new ArgumentException("It's not numbers");

        }
        
        public static double Product(this IEnumerable<int> numbers)
        {
            if (numbers.First().IsNumericType())
            {
                if (numbers.Count() == 0)
                    return 0;

                double result = 1;

                foreach (var item in numbers)
                    result *= item;

                return result;
            }
            else
                throw new ArgumentException("It's not numbers");
        }

        public static T Min<T>(this IEnumerable<T> numbers) where T : IComparable<T>
        {
            CheckingIfTheListIsEmpty(numbers);
            T result = numbers.First();

            foreach (var item in numbers)
                if (item.CompareTo(result) == -1)
                    result = item;

            return result;
        }

        public static T Max<T>(this IEnumerable<T> numbers) where T : IComparable<T>
        {
            CheckingIfTheListIsEmpty(numbers);
            T result = numbers.First();

            foreach (var item in numbers)
                if (item.CompareTo(result) == 1)
                    result = item;

            return result;
        }

        public static int Average(this IEnumerable<int> numbers)
        {
            if (numbers.First().IsNumericType())
            {
                CheckingIfTheListIsEmpty(numbers);

                int result = numbers.Sum();
                result = result / numbers.Count();
                return result;
            }
            else
                throw new ArgumentException("It's not numbers");
        }

        private static void CheckingIfTheListIsEmpty<T>(IEnumerable<T> numbers)
        {
            if (numbers.Count() == 0)
                throw new ArgumentException("The list/array is empty");
        }
        public static bool IsNumericType<T>(this T o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
    }
}
