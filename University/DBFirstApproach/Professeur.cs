using System;
using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    public partial class Professeur
    {
        public Professeur()
        {
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public List<Professeur> GetAll()
        {
            var result = new List<Professeur>();

            using (var db = new UniversityProgramContext())
                result.AddRange(db.Professeurs);

            return result;
        }

        public void Add()
        {
            using (var db = new UniversityProgramContext())
            {
                db.Professeurs.Add(this);
                db.SaveChanges();
            }
        }

        public void Update(Professeur updatedProf)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Professeurs.FirstOrDefault(item => item.Id == this.Id);

                if (entity != null)
                {
                    entity.FirstName = updatedProf.FirstName;
                    entity.LastName = updatedProf.LastName;
                    db.Professeurs.Update(entity);
                    db.SaveChanges();
                }
            }
        }

        public List<Professeur> Search(string name)
        {
            var results = new List<Professeur>();

            using(var db = new UniversityProgramContext())
                results = db.Professeurs.Where(item => item.FirstName == name).ToList();

            return results;
        }
        
        public void Delete()
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Professeurs.FirstOrDefault(item => item.Id == this.Id);
                db.Professeurs.Remove(entity);
                db.SaveChanges();
            }
        }
    }
}
