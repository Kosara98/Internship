using System;
using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    public partial class Subject
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentsSubjects>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfesseurId { get; set; }
        public string Description { get; set; }

        public virtual Professeur Professeur { get; set; }
        public virtual ICollection<StudentsSubjects> StudentsSubjects { get; set; }

        public void Add(Subject subj)
        {
            using(var db = new UniversityProgramContext())
            {
                db.Subjects.Add(subj);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // subject
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Subjects.FirstOrDefault(item => item.Id == id);
                db.Subjects.Remove(entity);
                db.SaveChanges();
            }
        }

        public void Update(Subject oldSubject, Subject newSubject)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Subjects.FirstOrDefault(item => item.Id == oldSubject.Id);
                entity.Name = newSubject.Name;
                entity.ProfesseurId = newSubject.ProfesseurId;
                entity.Description = newSubject.Description;
                db.Subjects.Update(entity);
                db.SaveChanges();
            }
        }

        public List<Subject> GetAll()
        {
            var subjects = new List<Subject>();

            using (var db = new UniversityProgramContext())
                subjects.AddRange(db.Subjects);

            return subjects;
        }

        public void Search()
        {

        }
    }
}
