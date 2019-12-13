using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstWithDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new StudentCourseRepository();

            Console.WriteLine("All the students in Math:");
            var mathStudents = new List<StudentCourse>();

            mathStudents.AddRange(subject.GetAll().Where(item => item.CourseId == 1));

            foreach (var item in mathStudents)
                Console.WriteLine($"{item.Student.Name}");
        }
    }
}
