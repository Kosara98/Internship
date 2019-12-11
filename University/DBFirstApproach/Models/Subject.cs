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
    }
}
