using System.ComponentModel.DataAnnotations;

namespace VacancyApp.ViewModels
{
    public class ProvincesViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Capital { get; set; }
        [Required]
        public float Area { get; set; }
        [Required]
        public IFormFile Mname { get; set; }
        public string Map { get; set; }
    }
}
