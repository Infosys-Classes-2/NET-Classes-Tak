using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        //public IActionResult Index()
        public async Task<IActionResult> AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(IdentityRole role)
        {
            var result = await roleManager.CreateAsync(role);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AssignRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(IdentityUser user)
        {
            var result = await userManager.CreateAsync(user);
            return View(user);
        }
    }
}
