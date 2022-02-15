using Kanban.Presentation.ViewModels.Account;
using Kanban.Service.Business.Data.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kanban.Presentation.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #region Login

        [HttpGet("login", Name = "account-login")]
        public IActionResult Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost("login", Name = "account-register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await _userService.PasswordSignInAsync(user, model.Password, true, false);

                    if (result.Succeeded)
                    {
                        if (string.IsNullOrEmpty(returnUrl))
                            return RedirectToAction("index", "home");

                        else if (Url.IsLocalUrl(returnUrl))
                            return LocalRedirect(returnUrl);
                    }
                }

                ModelState.AddModelError(string.Empty, "Email or password is not correct.");
            }


            return View(model);
        }

        #endregion

        public IActionResult Register()
        {
            return View();
        }
    }
}
