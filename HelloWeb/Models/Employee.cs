namespace HelloWeb.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    //public string Designation { get; set; }

    public int DesignationId { get; set; }
    public Designation Designation { get; set; }

    public byte level { get; set; }
    public DateTime JoinDate { get; set; }

    // Department Table ko Id sanga link
    // One employee has only one department or department has multple employees
    public int DepartmentId { get; set; }
    public Department Department { get; set; }

}
