using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    public class ProfesseurRepository : IProfesseurRepository
    {
        public void Add(Professeur professeur)
        {
            using (var db = new UniversityProgramContext())
            {
                db.Professeurs.Add(professeur);
                db.SaveChanges();
            }
        }

        public void Delete(Professeur professeur)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Professeurs.FirstOrDefault(item => item.Id == this.Id);
                db.Professeurs.Remove(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<DBFirstApproach.Professeur> GetAll()
        {
            using (var db = new UniversityProgramContext())
                return db.Professeurs.ToList();

        }

        public void Update(Professeur target, Professeur updatedProf)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Professeurs.FirstOrDefault(item => item.Id == target.Id);

                if (entity != null)
                {
                    entity.FirstName = updatedProf.FirstName;
                    entity.LastName = updatedProf.LastName;
                    db.Professeurs.Update(entity);
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<Professeur> Search(string name)
        {
            using (var db = new UniversityProgramContext())
                return db.Professeurs.Where(item => item.FirstName == name).ToList();
        }
    }
}
