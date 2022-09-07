using System.ComponentModel.DataAnnotations;

namespace HRM.Web.ViewModels;
public class EmployeeViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "We need your first name")]
    [Display(Name = "Your First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "We need your last name")]
    [Display(Name = "Your Last Name")]
    public string LastName { get; set; }

    public byte Level { get; set; }
    public DateTime JoinDate { get; set; }
    public bool? Active { get; set; }

    public IFormFile Avatar { get; set; }
    public string? ProfileImage { get; set; }

    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }

    public int DesignationId { get; set; }
    public string DesignationName { get; set; }
}