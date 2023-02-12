using System.ComponentModel.DataAnnotations;

namespace TestTask.Requests
{
    public class AddPositionRequest
    {
        public string Name { get; set; }
        [Range(0, 15)]
        public int Grade { get; set; }
    }
}
