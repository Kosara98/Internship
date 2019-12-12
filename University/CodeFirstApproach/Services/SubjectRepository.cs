using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstApproach
{
    public class SubjectRepository : ISubjectRepository
    {
        public void Add(Subject subject)
        {
            using (var db = new SchoolContext())
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
            }
        }

        public void Delete(Subject subject)
        {
            using (var db = new SchoolContext())
            {
                var entity = db.Subjects.FirstOrDefault(item => item.SubjectId == subject.SubjectId);
                db.Subjects.Remove(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Subject> GetAll()
        {
            using (var db = new SchoolContext())
                return db.Subjects.Include(item => item.Professor).ToList();
        }

        public void Update(Subject targetSubject, Subject updatedSubject)
        {
            using (var db = new SchoolContext())
            {
                var entity = db.Subjects.FirstOrDefault(item => item.SubjectId == targetSubject.SubjectId);
                entity.Name = updatedSubject.Name;
                entity.ProfessorId = updatedSubject.ProfessorId;
                entity.Description = updatedSubject.Description;
                db.Subjects.Update(entity);
                db.SaveChanges();
            }
        }
    }
}
