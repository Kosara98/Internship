using System.Collections.Generic;

namespace DBFirstApproach
{
    public interface ISubjectRepository
    {
        public IEnumerable<Subject> GetAll();
        public void Add(Subject subject);
        public void Delete(Subject subject);
        public void Update(Subject subject);
    }
}
