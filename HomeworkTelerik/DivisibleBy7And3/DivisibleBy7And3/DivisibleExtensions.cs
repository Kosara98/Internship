using System.Collections.Generic;
using System.Linq;

namespace DivisibleBy7And3
{
    public static class DivisibleExtensions
    {
        public static void DivideBy7And3(this IEnumerable<int> numbers)
        {
            var result = from num in numbers
                         where num % 7 == 0 && num % 3 == 0
                         select num;

            foreach (var item in result)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
