using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    public class StudentRepository : UniRepository<Student>, IStudentRepository
    {
        public override void Add(Student student)
        {
            using (var db = new UniversityProgramContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public override void Delete(Student student)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Students.FirstOrDefault(item => item.Id == student.Id);
                db.Students.Remove(entity);
                db.SaveChanges();
            }
        }

        public override IEnumerable<Student> GetAll()
        {
            using (var db = new UniversityProgramContext())
                return db.Students.ToList();
        }

        public override void Update(Student student)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Students.FirstOrDefault(item => item.Id == student.Id);
                db.Students.Update(entity);
                db.SaveChanges();
            }
        }
    }
}
