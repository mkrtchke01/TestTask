namespace TestTask.Requests
{
    public class UpdateEmployeeRequest
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<int> PositionIds { get; set; }
    }
}
