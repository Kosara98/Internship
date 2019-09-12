using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "aa", "aaaa", "dassadasd" };

            var maxLength = (from word in words
                            orderby word.Length
                            select word).Last();

            Console.WriteLine(maxLength);
        }
    }
}
