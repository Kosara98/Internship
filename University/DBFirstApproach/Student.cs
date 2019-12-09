using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    public partial class Student
    {
        public Student()
        {
            StudentsSubjects = new HashSet<StudentsSubjects>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FacultyNumber { get; set; }

        public virtual ICollection<StudentsSubjects> StudentsSubjects { get; set; }

        public void Add()
        {
            using (var db = new UniversityProgramContext())
            {
                db.Students.Add(this);
                db.SaveChanges();
            }
        }

        public List<Student> GetAll()
        {
            var students = new List<Student>();

            using (var db = new UniversityProgramContext())
                students = db.Students.ToList();
                
            return students;
        }

        public List<StudentsSubjects> Subjects()
        {
            var subj = new List<StudentsSubjects>();

            using (var db = new UniversityProgramContext())
                subj = db.StudentsSubjects.Include(item => item.Subject).Include(item => item.Student).ToList();

            return subj;
        }

        public void Update()
        {

        }

        public void Delete()
        {
            using (var db = new UniversityProgramContext())
            {
                var entity = db.Students.FirstOrDefault(item => item.Id == this.Id);
                db.Students.Remove(entity);
                db.SaveChanges();
            }
        }

        public List<Student> Search(string name)
        {
            var results = new List<Student>();

            using (var db = new UniversityProgramContext())
                results = db.Students.Where(item => item.Name == name).ToList();

            return results;
        }
    }
}
