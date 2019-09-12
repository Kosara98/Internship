using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGroups
{
    public static class StudentExtensions
    {
        //Problem 19
        public static void GroupedByGroupNumber(this List<Student> students)
        {
            var grouped = students.GroupBy(x => x.GroupNumber.GroupNumber).ToList();

            foreach (var i in grouped)
            {
                Console.WriteLine(i.Key);
                foreach (var item in i)
                {
                    Console.WriteLine(item.FirstName);
                }
            }
        }
        //Problem 10
        public static void CheckingForGroupTwo(this List<Student> students)
        {
            var result = from student in students
                             where student.GroupNumber.GroupNumber == 2
                             orderby student.FirstName
                             select student;

            foreach (var i in result)
                Console.WriteLine(i.FirstName);
        }
        
        public static void StudentsWithTwoMarks(this List<Student> students)
        {
            var marksLinq = from student in students
                            where student.Marks.Contains(2)
                            select new { FullName = $"{student.FirstName} {student.LastName}", Marks = string.Join(",", student.Marks) };

            var marks = students.Where(x => x.Marks.Contains(2)).
                Select(x => new { FullName = $"{x.FirstName} {x.LastName}", Marks = string.Join(",", x.Marks) });

            foreach (var i in marksLinq)
                Console.WriteLine(i);

            Console.WriteLine("--------");

            foreach (var i in marks)
                Console.WriteLine(i);
        }
    }
}
