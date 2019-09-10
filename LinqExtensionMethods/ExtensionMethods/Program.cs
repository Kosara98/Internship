using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Program
    {
        delegate double doubleIt(double value);

        static void Main(string[] args)
        {
            //WHERE()

            doubleIt dblIt = x => x * 2;
            Console.WriteLine($"5 * 2 = {dblIt(5)}");

            List<int> numList = new List<int> { 1, 9, 6, 4 };
            var eveList = numList.Where(a => a % 2 == 0).ToList();

            Console.WriteLine("-----------");

            var rangeList = numList.Where(x => (x > 2) && (x < 9)).ToList();

            foreach (var item in rangeList)
                Console.WriteLine(item);

            Console.WriteLine("-----------");

            List<int> flipList = new List<int>();
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                flipList.Add(random.Next(1, 3));
            }

            Console.WriteLine("Heads : {0}", flipList.Where(a => a == 1).ToList().Count());
            Console.WriteLine("Tails : {0}", flipList.Where(a => a == 2).ToList().Count());
            Console.WriteLine("-----------");

            var nameList = new List<string> { "Doug", "Sally", "Sue" };
            var sNameList = nameList.Where(x => x.StartsWith("S"));

            foreach (var item in sNameList)
                Console.WriteLine(item);

            Console.WriteLine("-----------");

            // SELECT()

            var oneToTen = new List<int>();
            oneToTen.AddRange(Enumerable.Range(1, 10));

            var squares = oneToTen.Select(x => x * x);

            foreach (var item in squares)
                Console.WriteLine(item);

            Console.WriteLine("-----------");

            //ZIP()

            List<int> listOne = new List<int>(new int[] { 1, 3, 4 });
            List<int> listTwo = new List<int>(new int[] { 4, 6, 7 });

            var sumList = listOne.Zip(listTwo, (x, y) => x + y);

            foreach (var item in sumList)
                Console.WriteLine(item);

            Console.WriteLine("-----------");

            //AGGREGATE()

            var numListTwo = new List<int>() { 1, 2, 3, 4, 5, 4, 3 };
            Console.WriteLine("Sum : {0}", numListTwo.Aggregate((a, b) => a + b));

            //AVERAGE()

            Console.WriteLine("Avg : {0}", numListTwo.AsQueryable().Average());

            //All() and ANY()

            Console.WriteLine("All > 3 : {0}", numList.All(x => x > 3));
            Console.WriteLine("Any > 3 : {0}", numList.Any(x => x > 3));

            //DISTINCT()
            Console.WriteLine("Distinct : {0}", string.Join(",",numList.Distinct()));

            //EXCEPT()
            Console.WriteLine("Except : {0}", string.Join(",", listOne.Except(listTwo)));

            //INTERSECT()
            Console.WriteLine("Interesect : {0}", string.Join(",", listOne.Intersect(listTwo)));
        }
    }

}
