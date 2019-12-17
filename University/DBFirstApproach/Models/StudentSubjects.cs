using System;
using System.Collections.Generic;

namespace DBFirstApproach
{
    public partial class StudentSubjects
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
