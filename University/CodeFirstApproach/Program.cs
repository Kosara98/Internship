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
            Console.WriteLine("All the students in Math:");
            var mathStudents = new List<StudentSubject>();

            using (var db = new SchoolContext())
                mathStudents = db.StudentSubjects.Include(item => item.Student).Include(item => item.Subject).Where(item => item.SubjectId == 1).ToList();

            foreach (var item in mathStudents)
                Console.WriteLine($"{item.Student.Name}");
        }
    }
}
