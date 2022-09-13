using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public AuthController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;

        }
        //public IActionResult Index()
        public IActionResult AddRole()
        {
            return View();
        }

        public IActionResult AssignRole()
        {
            return View();
        }
    }
}
