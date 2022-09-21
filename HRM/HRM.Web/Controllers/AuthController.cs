using HRM.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRM.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Roles()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(IdentityRole role)
        {
            var result = await roleManager.CreateAsync(role);
            return RedirectToAction(nameof(Roles));
        }

        public IActionResult AssignRole()
        {
            var users = userManager.Users.ToList();
            var roles = roleManager.Roles.ToList();

            UserRoleViewModel userRoleViewModel = new()
            {
                Users = users.Select(x => new SelectListItem { Text = x.UserName, Value = x.Id }),
                Roles = roles.Select(x => new RoleItem { Value = x.Name, IsSelected = false }).ToList()
            };

            return View(userRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await userManager.FindByIdAsync(userRoleViewModel.UserId);
            var rolesSelected = userRoleViewModel.Roles
                .Where(x => x.IsSelected)
                .Select(x => x.Value);

            foreach (var role in rolesSelected)
            {
                await userManager.AddToRoleAsync(user, role);
            }

            return RedirectToAction(nameof(AssignRole));
        }
    }
}
