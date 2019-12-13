using System.Collections.Generic;

namespace CodeFirstWithDB
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int ProfessorId { get; set; }
        public string Description { get; set; }

        public Professor Professor { get; set; }
        public IList<StudentCourse> StudentCourses { get; set; }
    }
}
