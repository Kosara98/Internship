using System.Collections.Generic;

namespace CodeFirstWithDB
{
    public interface IStudentRepository
    {
        public void Add(Student student);
        public void Update(Student targetStudent, Student updatedStudent);
        public void Delete(Student student);
        public IEnumerable<Student> GetAll();
    }
}
