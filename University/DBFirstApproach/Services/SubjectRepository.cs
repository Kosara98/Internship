using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    public class SubjectRepository : UniRepository<Subject>, ISubjectRepository 
    {
        public override void Add(Subject subject)
        {
            using (var db = new UniversityProgramContext())
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
            }
        }

        public override void Delete(Subject subject)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Subjects.FirstOrDefault(item => item.Id == subject.Id);
                db.Subjects.Remove(entity);
                db.SaveChanges();
            }
        }

        public override IEnumerable<Subject> GetAll()
        {
            using (var db = new UniversityProgramContext())
                return db.Subjects.Include(item => item.Professor).ToList();
        }

        public override void Update(Subject subject)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Subjects.FirstOrDefault(item => item.Id == subject.Id);
                db.Subjects.Update(entity);
                db.SaveChanges();
            }
        }
    }
}
