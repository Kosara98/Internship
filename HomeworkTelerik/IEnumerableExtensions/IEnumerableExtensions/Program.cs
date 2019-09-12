using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableExtensions
{
    partial class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i);
            }

           Console.WriteLine("The sum is: " + numbers.Sum());
           Console.WriteLine("The avarege is: " + numbers.Average());
           Console.WriteLine("The max is: " + numbers.Max());
           Console.WriteLine("The product is: " + numbers.Product());
           Console.WriteLine("The min is: " + numbers.Min());
        }
    }
}
