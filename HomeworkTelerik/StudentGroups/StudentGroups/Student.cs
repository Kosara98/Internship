using System.Collections.Generic;

namespace StudentGroups
{
    public class Student
    {
        public Student(string firstName, string lastName, int groupNumber, string email, string phone, List<double> marks, string fn)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GroupNumber = groupNumber;
            this.Email = email;
            this.Phone = phone;
            this.Marks = marks;
            this.FN = fn;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FN { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<double> Marks { get; set; }
        public int GroupNumber { get; set; }
    }
}
