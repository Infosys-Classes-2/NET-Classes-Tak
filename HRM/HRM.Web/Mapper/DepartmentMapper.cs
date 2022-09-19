using HRM.Web.Models;
using HRM.Web.ViewModels;

namespace HRM.Web.Mapper
{
    public static class DepartmentMapper
    {
        public static DepartmentViewModel ToViewModel(this Department department)  //Extension methods
        {
            DepartmentViewModel departmentViewModel = new()
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                Established = department.Established
            };

            return departmentViewModel;
        }
        public static Department ToModel(this DepartmentViewModel departmentViewModel)  //Extension methods
        {
            Department department = new()
            {
                Id = departmentViewModel.Id,
                Name = departmentViewModel.Name,
                Description = departmentViewModel.Description,
                Established = departmentViewModel.Established

            };

            return department;
        }
        public static List<DepartmentViewModel> ToViewModel(this List<Department> department)
        {
            var departmentViewModels = department.Select(x => ToViewModel(x)).ToList();
            return departmentViewModels;
        }

        public static List<Department> ToModel(this List<DepartmentViewModel> departmentViewModels)
        {
            var department = departmentViewModels.Select(x => ToModel(x)).ToList();
            return department;
        }

    }
}
