namespace StudentGroups
{
    public class Group
    {
        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }
        public int GroupNumber { get; set; }
        public string DepartmentName { get; set; }
    }
}
