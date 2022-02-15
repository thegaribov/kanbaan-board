using Kanban.Core.Entities;
using Kanban.Core.Enums.Organisation;
using Kanban.Core.Extensions.IdentityResult;
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
        private readonly IOrganisationService _organisationService;
        private readonly IUserOrganisationService _userOrganisationService;

        public AccountController(
            IUserService userService, 
            IOrganisationService organisationService,
            IUserOrganisationService userOrganisationService)
        {
            _userService = userService;
            _organisationService = organisationService;
            _userOrganisationService = userOrganisationService;
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

        [HttpPost("login", Name = "account-login")]
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

        #region Register

        [HttpGet("register", Name = "account-register")]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost("register", Name = "account-register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                //Create default admin user
                var newUser = new User
                {
                    FullName = model.FullName,
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userService.CreateAsync(newUser, model.Password);

                if (!result.Succeeded)
                {
                    result.AddToModelState(this.ModelState);
                    return View();
                }

                //Create organisation

                var newOrganisation = new Organisation
                {
                    Name = model.Organisation,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address
                };

                await _organisationService.CreateAsync(newOrganisation);

                //Create pivot record

                var organisationUser = new UserOrganisation
                {
                    OrganisationId = newOrganisation.Id,
                    UserId = newUser.Id,
                    Role = OrganisationRole.Admin
                };

                await _userOrganisationService.CreateAsync(organisationUser);


                return RedirectToRoute("account-login");
            }


            return View(model);
        }


        #endregion

        #region Logout

        //[HttpPost("logout", Name = "account-logout")]
        //public async Task<IActionResult> Logout()
        //{
        //    await _userService.SignOutAsync();
        //    return RedirectToAction("login", "account");
        //}


        #endregion
    }
}
