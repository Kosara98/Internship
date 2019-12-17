using System;
using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    public partial class Professor : BaseModel
    {
        public Professor()
        {
            Subjects = new HashSet<Subject>();
        }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
