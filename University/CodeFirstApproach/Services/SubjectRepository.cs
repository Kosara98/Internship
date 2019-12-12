namespace CodeFirstApproach
{
    public class SubjectRepository : ISubjectRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfessorId { get; set; }
        public string Description { get; set; }
    }
}
