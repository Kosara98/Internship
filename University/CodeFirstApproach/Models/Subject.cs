using System.Collections.Generic;

namespace CodeFirstApproach
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int ProfessorId { get; set; }
        public string Description { get; set; }

        public Professor Professor { get; set; }
        public IList<StudentSubject> StudentCourses { get; set; }
    }
}
