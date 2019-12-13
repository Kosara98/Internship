using System.Collections.Generic;
using System.Linq;

namespace CodeFirstWithDB
{

    public class StudentRepository : IStudentRepository
    {
        public void Add(Student student)
        {
            using (var db = new UniversityContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public void Delete(Student student)
        {
            using (var db = new UniversityContext())
            {
                var entity = db.Students.FirstOrDefault(item => item.StudentId == student.StudentId);
                db.Students.Remove(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Student> GetAll()
        {
            using (var db = new UniversityContext())
                return db.Students.ToList();
        }

        public void Update(Student targetStudent, Student updatedStudent)
        {
            using (var db = new UniversityContext())
            {
                var entity = db.Students.FirstOrDefault(item => item.StudentId == targetStudent.StudentId);
                entity.Name = updatedStudent.Name;
                entity.FacultyNumber = updatedStudent.FacultyNumber;
                db.Students.Update(entity);
                db.SaveChanges();
            }
        }
    }
}
