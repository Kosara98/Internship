using System.Collections.Generic;

namespace DBFirstApproach
{
    public interface IStudentRepository
    {
        public IEnumerable<DBFirstApproach.Student> GetAll();
        public void Add(Student student);
        public void Delete(Student student);
        public void Update(Student targetStudent, Student updatedStudent);
    }
}
