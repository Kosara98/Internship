using System.Collections.Generic;

namespace CodeFirstWithDB
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string FacultyNumber { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
    }
}
