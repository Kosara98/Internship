using System.Collections.Generic;

namespace CodeFirstApproach
{
    public interface IStudentSubjectRepository
    {
        public void Add(StudentSubject studentSubject);
        public void Delete(StudentSubject studentSubject);
        public IEnumerable<StudentSubject> GetAll();
    }
}
