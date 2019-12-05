using System;
using System.Collections.Generic;

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

        public void Add(Student student)
        {
            using (var db = new UniversityProgramContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public List<Student> GetAll()
        {
            var students = new List<Student>();

            using (var db = new UniversityProgramContext())
                students.AddRange(db.Students);

            return students;
        }

        public void Update()
        {

        }

        public void Delete()
        {

        }

        public void Search()
        {

        }
    }
}
