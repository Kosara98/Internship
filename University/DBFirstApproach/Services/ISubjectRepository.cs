using System.Collections.Generic;

namespace DBFirstApproach
{
    public interface ISubjectRepository
    {
        public IEnumerable<DBFirstApproach.Subject> GetAll();
        public void Add(Subject subject);
        public void Delete(Subject subject);
        public void Update(Subject target, Subject subject);
        public IEnumerable<Subject> Search(string name);
    }
}
