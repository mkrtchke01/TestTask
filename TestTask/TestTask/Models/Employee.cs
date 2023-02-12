namespace TestTask.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Position> Positions { get; set; }
    }
}
