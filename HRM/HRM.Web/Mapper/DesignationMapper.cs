using HRM.ApplicationCore.Models;
using HRM.Web.ViewModels;
using HRM.Web.ViewModels;


namespace HRM.Web.Mapper
{
    public static class DesignationMapper
    {
        public static DesignationViewModel ToViewModel(this Designation designation)  //Extension methods
        {
            DesignationViewModel designationViewModel = new()
            {
                Id = designation.Id,
                Name = designation.Name,
                Level = designation.Level,
                Description = designation.Description
            };

            return designationViewModel;
        }

        public static Designation ToModel(this DesignationViewModel designationViewModel)  //Extension methods
        {
            Designation designation = new()
            {
                Id = designationViewModel.Id,
                Name = designationViewModel.Name,
                Level = designationViewModel.Level,
                Description = designationViewModel.Description
            };

            return designation;
        }

        public static List<DesignationViewModel> ToViewModel(this List<Designation> designation)
        {
            var designationViewModels = designation.Select(x => ToViewModel(x)).ToList();
            return designationViewModels;
        }

        public static List<Designation> ToModel(this List<DesignationViewModel> designationViewModels)
        {
            var designation = designationViewModels.Select(x => ToModel(x)).ToList();
            return designation;
        }
    }
}
