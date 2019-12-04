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
    }
}
