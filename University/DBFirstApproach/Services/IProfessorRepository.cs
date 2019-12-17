using System.Collections.Generic;

namespace DBFirstApproach
{
    public interface IProfessorRepository
    {
        public IEnumerable<Professor> GetAll();
        public void Add(Professor professeur);
        public void Delete(Professor professeur);
        public void Update(Professor professeur);
    }
}
