using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    public partial class Subject : BaseModel
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubjects>();
        }
        public int ProfessorId { get; set; }
        public string Description { get; set; }

        public virtual Professor Professor { get; set; }
        public virtual ICollection<StudentSubjects> StudentsSubjects { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Professor.Id} - {Description}";
        }
    }
}
