namespace CodeFirstApproach
{
    public class ProfessorRepository : IProfessorRepository
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
