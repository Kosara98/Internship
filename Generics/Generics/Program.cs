using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //var number = new Nullable<int>(5);
            //Console.WriteLine($"Has Value ? : {number.HasValue}");
            //Console.WriteLine($"Value: {number.GetValueOrDefault()}");
            
            IList<int> list = new CustomList<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }
            list.Insert(2, 0);
            list.Remove(0);
            list.RemoveAt(3);

            Console.WriteLine("-------------------");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
