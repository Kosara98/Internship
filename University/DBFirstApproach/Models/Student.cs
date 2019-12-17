using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    public partial class Student : BaseModel
    {
        public Student()
        {
            StudentsSubjects = new HashSet<StudentSubjects>();
        }
        public string FacultyNumber { get; set; }

        public virtual ICollection<StudentSubjects> StudentsSubjects { get; set; }

        public override string ToString()
        {
            return $"{Name} - {FacultyNumber}";
        }
    }
}
