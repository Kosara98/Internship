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
            IList<int> list = new List<int>();

            for (int i = 0; i < 70; i++)
            {
                list.Add(i);
            }
            list.Remove(50);
            Console.WriteLine(list.Contains(50));
            Console.WriteLine("-------------");
            list.Insert(50, 50);
            Console.WriteLine(list.Contains(50));
            Console.WriteLine("-------------------");
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
