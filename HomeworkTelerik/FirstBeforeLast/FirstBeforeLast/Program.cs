using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBeforeLast
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students =
            {
                new Student("Ivan","Petrov"),
                new Student("Georgi", "Ivanov"),
                new Student("Stefan", "Kostov"),
                new Student("Aaaaaa","YYYY")
            };

            //Problem 3: First before Last
            var result = FirstNameBeforeLastName(students);
            var resultLambda = students.Where(x => x.FirstName[0] < x.LastName[0]).ToArray();

            foreach (var item in result)
                Console.WriteLine(item.FirstName);

            foreach (var item in resultLambda)
                Console.WriteLine(item.FirstName);

            //Problem 5: Order students
            var orderStudentsLambda = students.OrderByDescending(x => x.FirstName).ThenBy(x => x.LastName);
            var orderStudents = from student in students
                                orderby student.FirstName descending, student.LastName 
                                select student;

            foreach (var item in orderStudentsLambda)
                Console.WriteLine(item.FirstName);
            foreach (var item in orderStudents)
                Console.WriteLine(item.FirstName);


        }
        public static IEnumerable<Student> FirstNameBeforeLastName(IEnumerable<Student> students)
        {
            var result = from student in students
                         where student.FirstName[0] < student.LastName[0]
                         orderby student.FirstName
                         select student;

            return result;
        }
    }
}
