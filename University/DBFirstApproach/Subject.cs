using Microsoft.EntityFrameworkCore;
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

        public void Add()
        {
            using (var db = new UniversityProgramContext())
            {
                db.Subjects.Add(this);
                db.SaveChanges();
            }
        }

        public void Delete() 
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Subjects.FirstOrDefault(item => item.Id == this.Id);
                db.Subjects.Remove(entity);
                db.SaveChanges();
            }
        }

        public void Update(Subject newSubject)
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Subjects.FirstOrDefault(item => item.Id == this.Id);
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
                subjects = db.Subjects.Include(item => item.Professeur).ToList();

            return subjects;
        }

        public List<Subject> Search(string name)
        {
            var results = new List<Subject>();

            using (var db = new UniversityProgramContext())
                results = db.Subjects.Include(i => i.Professeur).Where(item => item.Name == name).ToList();

            return results;
        }
    }
}
