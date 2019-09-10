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
            IList<int> list = new CustomList<int>();

            for (int i = 0; i < 20; i++)
            {
                list.Insert(i,i);
            }
            Console.WriteLine("--");
            //list.RemoveAt(5);
            Console.WriteLine("-------------------");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
