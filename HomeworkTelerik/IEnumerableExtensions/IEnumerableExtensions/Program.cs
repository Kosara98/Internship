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
            List<int> nums = new List<int>();
            for (int i = 10; i > 2; i--)
            {
                nums.Add(i);
            }

            Console.WriteLine("The sum is: " + nums.Sum());
            Console.WriteLine("The avarege is: " + nums.Average());
            Console.WriteLine("The max is: " + nums.Max());
            Console.WriteLine("The product is: " + nums.Product());
            Console.WriteLine("The min is: " + nums.Min());
        }
    }
}
