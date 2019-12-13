using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstWithDB
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        public void Add(StudentCourse studentCourse)
        {
            using (var db = new UniversityContext())
            {
                db.StudentCourses.Add(studentCourse);
                db.SaveChanges();
            }
        }

        public IEnumerable<StudentCourse> GetAll()
        {
            using (var db = new UniversityContext())
                return db.StudentCourses.Include(item => item.Student).Include(item => item.Course).ToList();
        }
    }
}
