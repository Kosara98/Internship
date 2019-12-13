using System.Collections.Generic;

namespace CodeFirstWithDB
{
    public interface IStudentCourseRepository
    {
        public void Add(StudentCourse studentCourse);
        public IEnumerable<StudentCourse> GetAll();
    }
}
