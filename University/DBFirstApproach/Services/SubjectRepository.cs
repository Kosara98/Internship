using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    public class SubjectRepository : ISubjectRepository
    {
        public void Add(Subject subject)
        {
            using (var db = new UniversityProgramContext())
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
            }
        }

        public void Delete(Subject subject)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Subjects.FirstOrDefault(item => item.Id == subject.Id);
                db.Subjects.Remove(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Subject> GetAll()
        {
            using (var db = new UniversityProgramContext())
                return db.Subjects.Include(item => item.Professeur).ToList();
        }

        public void Update(Subject targetSubject, Subject newSubject)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Subjects.FirstOrDefault(item => item.Id == targetSubject.Id);
                entity.Name = newSubject.Name;
                entity.ProfesseurId = newSubject.ProfesseurId;
                entity.Description = newSubject.Description;
                db.Subjects.Update(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Subject> Search(string name)
        {
            using (var db = new UniversityProgramContext())
               return db.Subjects.Include(i => i.Professeur).Where(item => item.Name == name).ToList();

        }
    }
}
