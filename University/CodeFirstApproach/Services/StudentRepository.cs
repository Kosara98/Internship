namespace CodeFirstApproach
{
    public class StudentRepository : IStudentRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FacultyNumber { get; set; }
    }
}
