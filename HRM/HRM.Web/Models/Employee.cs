using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace HRM.Web.Models;

public class Employee
{
    public int Id { get; set; }
    [DisplayName("Your First Name")]
    //[Required(ErrorMessage="First Name is Mendetory.")]
    public string FirstName { get; set; }
    [DisplayName("Your Last Name")]
    public string LastName { get; set; }
    //public string Designation { get; set; }
    
    // One employee has only one disignation, single designation can be for multiple employees
    public int DesignationId { get; set; }
    [DisplayName("Your Designation")]
    public Designation Designation { get; set; }

    [DisplayName("Your Level")]
    public byte level { get; set; }
    [DisplayName("Your Join Date")]
    public DateTime JoinDate { get; set; }

    // Department Table ko Id sanga link
    // One employee has only one department or department has multple employees
    public int DepartmentId { get; set; }
    [DisplayName("Your Department")]
    public Department Department { get; set; }

    // For Image Path Store
    /*
    [DisplayName("Your Image")]
    public string ImagePath { get; set; }

    // For Image Store
    public HttpPostedFileBase ImageFile { get; set; }
    */
}
