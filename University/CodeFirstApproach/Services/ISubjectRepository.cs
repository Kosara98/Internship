using System.Collections.Generic;

namespace CodeFirstApproach
{
    public interface ISubjectRepository
    {
        public void Add(Subject subject);
        public void Update(Subject targetSubject, Subject updatedSubject);
        public void Delete(Subject subject);
        public IEnumerable<Subject> GetAll();
    }
}
