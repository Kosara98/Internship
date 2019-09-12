using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRange
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new[]
            {
                new {FirstName = "Ivan", LastName = "Ivanov", Age = 25},
                new {FirstName = "Gosho", LastName = "Marinov", Age = 16},
                new {FirstName = "Maria", LastName = "Todorova", Age = 20}
            };

            var result = from student in students
                         where student.Age >= 18 && student.Age <= 24
                         select student;

            var resultLambda = students.Where(x => x.Age >= 18 && x.Age <= 24);

            foreach (var item in result)
                Console.WriteLine($"The students between 18 and 24 are :  {item.FirstName} {item.LastName}" );
        }
    }
}
