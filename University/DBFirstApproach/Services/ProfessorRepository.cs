using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    public class ProfessorRepository : UniRepository<Professor>, IProfessorRepository
    {
        public override void Add(Professor professeur)
        {
            using (var db = new UniversityProgramContext())
            {
                db.Professors.Add(professeur);
                db.SaveChanges();
            }
        }

        public override void Delete(Professor professeur)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Professors.FirstOrDefault(item => item.Id == professeur.Id);
                db.Professors.Remove(entity);
                db.SaveChanges();
            }
        }

        public override IEnumerable<Professor> GetAll()
        {
            using (var db = new UniversityProgramContext())
                return db.Professors.ToList();

        }

        public override void Update(Professor prof)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Professors.FirstOrDefault(item => item.Id == prof.Id);

                if (entity != null)
                {
                    db.Professors.Update(entity);
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<Professor> Search(string name)
        {
            using (var db = new UniversityProgramContext())
                return db.Professors.Where(item => item.Name == name).ToList();
        }
    }
}
