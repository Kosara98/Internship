using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            students.Add(new Student("Ivan", "Petrov", 2, "ivan.petrov@abv.bg", "+2/892646",new List<double>{ 6,5,6}, "06060606"));
            students.Add(new Student("Petq", "Ivanova", 4, "petq.ivanova@gmail.bg", "+52/89652", new List<double> { 6, 4, 4 }, "123456"));
            students.Add(new Student("Georgi", "Todorov", 2, "georgi.todorov@gamil.com", "+2/598996", new List<double> { 3, 2, 4 }, "025896"));
            students.Add(new Student("Stefan", "Anestev", 1, "stefan.Anestev@abv.bg", "+2/598786", new List<double> { 5, 2, 5 }, "0213064"));

            //Problem 9 : Student groups
            var resultLinq = from student in students
                             where student.GroupNumber == 2
                             orderby student.FirstName
                             select student;

            var result = students.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName);

            foreach (var i in resultLinq)
                Console.WriteLine(i.FirstName);

            Console.WriteLine("--------");

            foreach (var i in result)
                Console.WriteLine(i.FirstName);

            //Problem 10 : Student groups extensions
            students.CheckingForGroupTwo();

            //Problem 11 : Extract students by email
            var emailAbvLinq = from student in students
                               where student.Email.Contains("abv.bg")
                               select student;

            var emailAbv = students.Where(x => x.Email.Contains("abv.bg"));

            foreach (var i in emailAbvLinq)
                Console.WriteLine(i.FirstName);

            Console.WriteLine("--------");

            foreach (var i in emailAbv)
                Console.WriteLine(i.FirstName);

            //Problem 12 : Extract students by phone
            var phoneSofiaLinq = from student in students
                                 where student.Phone.StartsWith("+2")
                                 select student;

            var phoneSofia = students.Where(x => x.Phone.StartsWith("+2"));

            foreach (var i in phoneSofiaLinq)
                Console.WriteLine(i.FirstName);

            Console.WriteLine("--------");

            foreach (var i in phoneSofia)
                Console.WriteLine(i.FirstName);

            //Problem 13: Extract students by marks
            var marksLinq = from student in students
                            where student.Marks.Contains(6)
                            select new { FullName = $"{student.FirstName} {student.LastName}", Marks = string.Join(",", student.Marks) };

            var marks = students.Where(x => x.Marks.Contains(6)).
                Select(x => new { FullName = $"{x.FirstName} {x.LastName}", Marks = string.Join(",",x.Marks) });

            foreach (var i in marksLinq)
                Console.WriteLine(i);

            Console.WriteLine("--------");

            foreach (var i in marks)
                Console.WriteLine(i);

            //Problem 14 : Extract students with two marks
            students.StudentsWithTwoMarks();

            //Problem 15 : Extract mars
            var marks06Linq = from student in students
                              where student.FN[4] == '0' && student.FN[5] == '6'
                              select string.Join(",", student.Marks);

            var marks06 = students.Where(x => x.FN[4] == '0' && x.FN[5] == '6').Select(x => string.Join(",", x.Marks));

            foreach (var i in marks06Linq)
                Console.WriteLine(i);

            Console.WriteLine("--------");

            foreach (var i in marks06)
                Console.WriteLine(i);
        }
    }
}
