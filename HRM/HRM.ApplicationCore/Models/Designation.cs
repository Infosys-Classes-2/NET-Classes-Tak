namespace HRM.ApplicationCore.Models
{
    public class Designation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        // Making nullable ?
        // public string? Description { get; set; }
        public string Description { get; set; }
    }
}
