using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstApproach
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new StudentSubjectRepository();

            Console.WriteLine("All the students in Math:");
            var mathStudents = new List<StudentSubject>();

            mathStudents.AddRange(subject.GetAll().Where(item => item.SubjectId == 1));

            foreach (var item in mathStudents)
                Console.WriteLine($"{item.Student.Name}");
        }
    }
}
