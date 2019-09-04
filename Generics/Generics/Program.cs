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
            List<int> list = new List <int>();
            list.Add(6);
            list.Clear();
            list.Add(5);
            list.Add(4);
            Console.WriteLine(list.IndexOf(4));

            CustomList<int> customList = new CustomList<int>();
            customList.Add(5);
            Console.WriteLine(customList.IndexOf(5));
        }
    }
}
