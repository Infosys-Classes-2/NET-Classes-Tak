using HRM.ApplicationCore.Models;
using HRM.Web.ViewModels;

namespace HRM.Web.Mapper
{
    public static class EmployeeMapper
    {
        public static EmployeeViewModel ToViewModel(this Employee employee)  //Extension methods
        {
            EmployeeViewModel employeeViewModel = new()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Level = employee.Level,
                Active = employee.Active,
                JoinDate = employee.JoinDate,
                ProfileImage = employee.ProfileImage,
                DepartmentName = employee.Department?.Name,
                DesignationName = employee.Designation?.Name
            };

            return employeeViewModel;
        }

        public static Employee ToModel(this EmployeeViewModel employeeViewModel)  //Extension methods
        {
            Employee employee = new()
            {
                Id = employeeViewModel.Id,
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                Level = employeeViewModel.Level,
                Active = employeeViewModel.Active,
                JoinDate = employeeViewModel.JoinDate,
                ProfileImage = employeeViewModel.ProfileImage,
                DepartmentId = employeeViewModel.DepartmentId,
                DesignationId = employeeViewModel.DesignationId
            };

            return employee;
        }

        public static List<EmployeeViewModel> ToViewModel(this List<Employee> employees)
        {
            var employeeViewModels = employees.Select(x => ToViewModel(x)).ToList();
            return employeeViewModels;
        }

        public static List<Employee> ToModel(this List<EmployeeViewModel> employeeViewModels)
        {
            var employees = employeeViewModels.Select(x => ToModel(x)).ToList();
            return employees;
        }
    }
}
