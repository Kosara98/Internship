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
    }
}
