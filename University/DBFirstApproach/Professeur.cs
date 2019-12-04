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
        public string Name { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public List<string> ShowAll()
        {
            var result = new List<string>();

            using (var db = new UniversityProgramContext())
                foreach (var item in db.Professeurs)
                    result.Add(item.Name);

            return result;
        }

        public void Add(string name)
        {
            using (var db = new UniversityProgramContext())
            {
                db.Professeurs.Add(new Professeur { Name = name });
                db.SaveChanges();
            }
        }

        public void Update(string prof, string newProf, int id)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Professeurs.FirstOrDefault(item => item.Id == id);

                if (entity != null)
                {
                    entity.Name = newProf;
                    db.Professeurs.Update(entity);
                    db.SaveChanges();
                }
            }
        }

        public void Search(string name)
        {

        }
        
        public void Delete()
        {
            using (var db = new UniversityProgramContext())
            {
                db.Professeurs.Remove(this);
                db.SaveChanges();
            }
        }
    }
}
