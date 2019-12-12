using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstApproach
{
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        public void Add(StudentSubject studentSubject)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(StudentSubject studentSubject)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<StudentSubject> GetAll()
        {
            using (var db = new SchoolContext())
                return db.StudentSubjects.Include(item => item.Student).Include(item => item.Subject).ToList();
        }
    }
}
