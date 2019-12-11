using System.Collections.Generic;

namespace DBFirstApproach
{
    public interface IStudentRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FacultyNumber { get; set; }

        public IEnumerable<DBFirstApproach.Student> GetAll();
        public void Add(Student student);
        public void Delete(Student student);
        public void Update(Student updatedStudent);
    }
}
