﻿using System;
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
            for (int i = 0; i < 1000; i++)
            {
                list.Insert(i, i);
            }
            Console.WriteLine("------------------------");
            int number = 14;
            Console.WriteLine("Contains:" + list.Contains(number));
            list.Remove(4);
            Console.WriteLine("Contains:" + list.Contains(4));
            list.Clear();
            list.Add(number);
            list.Add(5);
            list.Add(4);
            list.Add(3);

            Console.WriteLine("------------");

            ////var enumarator = list.GetEnumerator();
            ////while (enumarator.MoveNext())
            ////{
            ////    Console.WriteLine(enumarator.Current);
            ////}

            ////foreach (var item in list)
            ////{
            ////    Console.WriteLine(item);
            ////}
            
            //Console.WriteLine(list.Contains(number));
            //Console.WriteLine(list.Count);

            //Console.WriteLine("Index of  14 before insert " + list.IndexOf(number));
            //list.Insert(0, 3);
            //Console.WriteLine("Index of  14 after insert " + list.IndexOf(number));
            //Console.WriteLine("Index of 3 " + list.IndexOf(3));
            //Console.WriteLine(list.Count);
            //Console.WriteLine("------------");
            //int[] copy = new int[22];
            //list.CopyTo(copy, 0);

            //foreach (var item in copy)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
