namespace TestTask.Requests
{
    public class AddEmployeeRequest
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<int> PositionIds { get; set; }
    }
}
