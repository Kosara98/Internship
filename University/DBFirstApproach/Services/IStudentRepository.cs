using System.Collections.Generic;

namespace DBFirstApproach
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAll();
        public void Add(Student student);
        public void Delete(Student student);
        public void Update(Student student);
    }
}
