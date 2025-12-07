using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tabula.Models.Account;

namespace Tabula.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistrationPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {

            if (!ModelState.IsValid)
            {

            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register()
        {
            if (!ModelState.IsValid)
            {

            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Login");
        }
    }
}
