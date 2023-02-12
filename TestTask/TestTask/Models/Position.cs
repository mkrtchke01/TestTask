namespace TestTask.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
