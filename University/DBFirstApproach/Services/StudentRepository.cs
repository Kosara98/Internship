using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    public class StudentRepository : IStudentRepository
    {
        public void Add(Student student)
        {
            using (var db = new UniversityProgramContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public void Delete(Student student)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Students.FirstOrDefault(item => item.Id == student.Id);
                db.Students.Remove(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<DBFirstApproach.Student> GetAll()
        {
            using (var db = new UniversityProgramContext())
                return db.Students.ToList();
        }

        public void Update(Student targetStudent, Student student)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Students.FirstOrDefault(item => item.Id == targetStudent.Id);
                entity.Name = student.Name;
                entity.FacultyNumber = student.FacultyNumber;
                db.Students.Update(entity);
                db.SaveChanges();
            }
        }
    }
}
