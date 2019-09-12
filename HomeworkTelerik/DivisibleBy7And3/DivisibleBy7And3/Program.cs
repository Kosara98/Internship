using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisibleBy7And3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 3, 21, 42 };
            numbers.DivideBy7And3();

            var result = numbers.Where(x => x % 7 == 0 && x % 3 == 0);
            foreach (var item in result)
                Console.WriteLine(item);
        }
    }
}
