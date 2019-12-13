using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstWithDB
{
    public class CourseRepository : ICourseRepository
    {
        public void Add(Course course)
        {
            using (var db = new UniversityContext())
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }
        }

        public void Delete(Course course)
        {
            using (var db = new UniversityContext())
            {
                var entity = db.Courses.FirstOrDefault(item => item.CourseId == course.CourseId);
                db.Courses.Remove(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Course> GetAll()
        {
            using (var db = new UniversityContext())
                return db.Courses.Include(item => item.Professor).ToList();
        }

        public void Update(Course targetCourse, Course updatedCourse)
        {
            using (var db = new UniversityContext())
            {
                var entity = db.Courses.FirstOrDefault(item => item.CourseId == targetCourse.CourseId);
                entity.Name = updatedCourse.Name;
                entity.ProfessorId = updatedCourse.ProfessorId;
                entity.Description = updatedCourse.Description;
                db.Courses.Update(entity);
                db.SaveChanges();
            }
        }
    }
}
