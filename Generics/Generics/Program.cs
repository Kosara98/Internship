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
            for (int i = 0; i < 20; i++)
            {
                list.Add(i);
            }
            Console.WriteLine("------------------------");

            var e = list.GetEnumerator();
          
            while(e.MoveNext())
            {
                if (e.Current.Equals(4))
                {
                    e.Reset();
                    break;
                }
                Console.WriteLine(e.Current);
            }

            Console.WriteLine("-------------------");
            while (e.MoveNext())
            {
                Console.WriteLine(e.Current);
            }
        }
    }
}
