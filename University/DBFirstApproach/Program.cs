using System;
using System.Collections.Generic;

namespace DBFirstApproach
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pick a number:");
            Console.WriteLine("1.Professuers");
            Console.WriteLine("2.Students");
            Console.WriteLine("3.Subjects");
            string choosenTable = Console.ReadLine();

            Console.WriteLine("Choose action:");
            Console.WriteLine("1.Show all");
            Console.WriteLine("2.Add new");
            Console.WriteLine("3.Update");
            Console.WriteLine("4.Delete");
            Console.WriteLine("5.Search");
            string choosenOption = Console.ReadLine();

            Professeur test = new Professeur();
            List<string> result = test.ShowAll();
            foreach (var item in result)
                Console.WriteLine(item);

        }
    }
}
