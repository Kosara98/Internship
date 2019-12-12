using System.Collections.Generic;
using System.Linq;

namespace CodeFirstApproach
{
    public class StudentRepository : IStudentRepository
    {
        public void Add(Student student)
        {
            using (var db = new SchoolContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public void Delete(Student student)
        {
            using (var db = new SchoolContext())
            {
                var entity = db.Students.FirstOrDefault(item => item.StudentId == student.StudentId);
                db.Students.Remove(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Student> GetAll()
        {
            using (var db = new SchoolContext())
                return db.Students.ToList();
        }

        public void Update(Student targetStudent, Student updateStudent)
        {
            throw new System.NotImplementedException();
        }
    }
}
