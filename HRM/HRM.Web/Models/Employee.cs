using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace HRM.Web.Models;

public class EmployeeViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    // One employee has only one disignation, single designation can be for multiple employees
    public int DesignationId { get; set; }
    public string DesignationName { get; set; }
    public byte Level { get; set; }
    public DateTime JoinDate { get; set; }

    // Department Table ko Id sanga link
    // One employee has only one department or department has multple employees
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public bool? Active { get; set; }
    public string? ProfileImage { get; set; }
}
