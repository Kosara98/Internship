using System.Collections.Generic;

namespace CodeFirstApproach
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string FacultyNumber { get; set; }
        public IList<StudentSubject> StudentCourses { get; set; }
    }
}
