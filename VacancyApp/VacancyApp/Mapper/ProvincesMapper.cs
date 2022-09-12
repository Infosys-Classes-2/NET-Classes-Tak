using Microsoft.AspNetCore.Identity;
using System.Data.Common;
using VacancyApp.ApplicationCore.Models;
using VacancyApp.ViewModels;

namespace VacancyApp.Mapper
{
    public static class ProvincesMapper
    {
        public static ProvincesViewModel ToViewModel(this Provinces province)
        {
            ProvincesViewModel provinceViewModel = new()
            {
                Name = province.Name,
                Capital = province.Capital,
                Area = province.Area,
                Map = province.Map
            };
            return provinceViewModel;
        }

        public static Provinces ToModel(this ProvincesViewModel provincesViewModel)
        {
            Provinces provinces = new()
            {
                Name = provincesViewModel.Name,
                Capital = provincesViewModel.Capital,
                Area = provincesViewModel.Area,
                Map = provincesViewModel.Map
            };
            return provinces;
        }
        public static List<ProvincesViewModel> ToViewModel(this List<Provinces> provinces)
        {
            var provincesViewModels = provinces.Select(x => ToViewModel(x)).ToList();
            return provincesViewModels;
        }
        public static List<Provinces> ToModel(this List<ProvincesViewModel> provincesViewModels)
        {
            var provinces = provincesViewModels.Select(x => ToModel(x)).ToList();
            return provinces;
        }
    }
}
