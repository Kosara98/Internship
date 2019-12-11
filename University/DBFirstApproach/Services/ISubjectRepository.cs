using System.Collections.Generic;

namespace DBFirstApproach
{
    public interface ISubjectRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfesseurId { get; set; }
        public string Description { get; set; }

        public IEnumerable<DBFirstApproach.Subject> GetAll();
        public void Add(Subject subject);
        public void Delete(Subject subject);
        public void Update(Subject target, Subject subject);
        public IEnumerable<Subject> Search(string name);
    }
}
