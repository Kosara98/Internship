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

            students.Add(new Student("Ivan", "Petrov", new Group(2, "Mathematics"), "ivan.petrov@abv.bg", "+2/892646", new List<double> { 6, 5, 6 }, "06060606"));
            students.Add(new Student("Petq", "Ivanova", new Group(1, "Biology"), "petq.ivanova@gmail.bg", "+52/89652", new List<double> { 6, 4, 4 }, "123456"));
            students.Add(new Student("Georgi", "Todorov", new Group(2, "Mathematics"), "georgi.todorov@gamil.com", "+2/598996", new List<double> { 3, 2, 4 }, "025896"));
            students.Add(new Student("Stefan", "Anestev", new Group(3, "French"), "stefan.Anestev@abv.bg", "+2/598786", new List<double> { 5, 2, 5 }, "0213064"));

            //Problem 9 : Student groups
            var resultLinq = from student in students
                             where student.GroupNumber.GroupNumber == 2
                             orderby student.FirstName
                             select student;

            var result = students.Where(x => x.GroupNumber.GroupNumber == 2).OrderBy(x => x.FirstName);

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
                Select(x => new { FullName = $"{x.FirstName} {x.LastName}", Marks = string.Join(",", x.Marks) });

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

            //Problem 16 : Groups

            var mathStudentsLinq = from student in students
                                   where student.GroupNumber.DepartmentName == "Mathematics"
                                   select student;

            var mathStudents = students.Where(x => x.GroupNumber.DepartmentName == "Mathematics");

            foreach (var i in mathStudentsLinq)
                Console.WriteLine(i.FirstName);

            Console.WriteLine("--------");

            foreach (var i in mathStudents)
                Console.WriteLine(i.FirstName);

            //Problem 18 : Grouped by GroupNumber
            var groupedLinq = from student in students
                              group student.FirstName by student.GroupNumber.GroupNumber into g
                              select new { Group = g.Key, Students = g.ToList() };
      
            var grouped = students.GroupBy(x => x.GroupNumber.GroupNumber).ToList();

            foreach (var i in groupedLinq)
                Console.WriteLine($"{i.Group} {string.Join(",", i.Students)}");

            Console.WriteLine("--------");

            foreach (var i in grouped)
            {
                Console.WriteLine(i.Key);
                foreach (var item in i)
                {
                    Console.WriteLine(item.FirstName);
                }
            }

            //Problem 19: Grouped by GroupName extensions
            students.GroupedByGroupNumber();
        }
    }
}
