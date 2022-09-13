using Microsoft.Build.Framework;

namespace HRM.Web.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Established { get; set; }
    }
}
