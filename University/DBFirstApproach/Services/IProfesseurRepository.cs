using System.Collections.Generic;

namespace DBFirstApproach
{
    public interface IProfesseurRepository 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<DBFirstApproach.Professeur> GetAll();
        public void Add(Professeur professeur);
        public void Delete(Professeur professeur);
        public void Update(Professeur target,Professeur updatedProf);
        public IEnumerable<Professeur> Search(string firstName);
    }
}
