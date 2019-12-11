using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    public class StudentRepository : IStudentRepository
    {
        public int Id { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string FacultyNumber { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

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
            throw new System.NotImplementedException();
        }
    }
}
