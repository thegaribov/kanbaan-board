using Kanban.Core.Entities;
using Kanban.Core.Enums.Organisation;
using Kanban.Core.Extensions.IdentityResult;
using Kanban.Presentation.ViewModels.Organisation;
using Kanban.Service.Business.Data.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Presentation.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class OrganisationController : Controller
    {
        #region ctor

        private readonly IUserService _userService;
        private readonly IOrganisationService _organisationService;
        private readonly IUserOrganisationService _userOrganisationService;

        public OrganisationController(
            IUserService userService,
            IOrganisationService organisationService,
            IUserOrganisationService userOrganisationService)
        {
            _userService = userService;
            _organisationService = organisationService;
            _userOrganisationService = userOrganisationService;
        }

        #endregion

        #region Index

        [HttpGet("~/", Name = "organisation-index")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userService.GetUserAsync(User);

            var userOrganisations = await _userOrganisationService.GetAllWithUserAndOrganisationByUserAsync(currentUser.Id);

            var model = new OrganisationsViewModel();

            foreach (var userOrganisation in userOrganisations)
            {
                var owner = await _userOrganisationService.GetOrganisationOwnerByOrganisationAsync(userOrganisation.OrganisationId);
                var members = await _userOrganisationService.GetOrganisationMembersFullNameAsync(userOrganisation.OrganisationId);



                model.Organisations.Add(new OrganisationViewModel
                {
                    Id = userOrganisation.Organisation?.Id,
                    Name = userOrganisation.Organisation?.Name,
                    Owner = $"{owner.FullName} ({owner.Email})",
                    PhoneNumber = userOrganisation.Organisation?.PhoneNumber,
                    Address = userOrganisation.Organisation?.Address,
                    IsCurrentUserOwner = currentUser.Email == owner.Email,
                    CreatedAt = userOrganisation.Organisation?.CreatedAt,
                    Members = members
                });
            }

            return View(model);
        }

        #endregion

        #region Edit

        [HttpGet("{id}/edit", Name = "organisation-edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var currentUser = await _userService.GetUserAsync(User);

            //Check whether organisation belongs to current user or not
            var isOwner = await _userOrganisationService.IsOwnerAsync(currentUser.Id, id);
            if (!isOwner) return NotFound();

            var organisation = await _organisationService.GetAsync(id);

            var model = new OrganisationEditViewModel
            {
                Id = organisation.Id,
                Name = organisation.Name,
                PhoneNumber = organisation.PhoneNumber,
                Address = organisation.Address
            };

            return View(model);
        }

        [HttpPost("{id}/edit", Name = "organisation-edit")]
        public async Task<IActionResult> Edit(OrganisationEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userService.GetUserAsync(User);

                //Check whether organisation belongs to current user or not
                var isOwner = await _userOrganisationService.IsOwnerAsync(currentUser.Id, model.Id);
                if (!isOwner) return NotFound();

                var organisation = await _organisationService.GetAsync(model.Id);

                organisation.Name = model.Name;
                organisation.Address = model.Address;
                organisation.PhoneNumber = model.PhoneNumber;

                await _organisationService.UpdateAsync(organisation);

                return RedirectToRoute("organisation-index");
            }


            return View(model);
        }

        #endregion

        #region AddMember

        [HttpGet("{organisationId}/addmember", Name = "organisation-add-member")]
        public async Task<IActionResult> AddMember(int organisationId)
        {
            var currentUser = await _userService.GetUserAsync(User);

            //Check whether organisation belongs to current user or not
            var isOwner = await _userOrganisationService.IsOwnerAsync(currentUser.Id, organisationId);
            if (!isOwner) return NotFound();

            var organisation = await _organisationService.GetAsync(organisationId);

            var model = new AddMemberToOrganisationViewModel
            {
                OrganisationId = organisationId,
                OrganisationName = organisation.Name
            };

            return View(model);
        }

        [HttpPost("{organisationId}/addmember", Name = "organisation-add-member")]
        public async Task<IActionResult> AddMember(AddMemberToOrganisationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userService.GetUserAsync(User);

                //Check whether organisation belongs to current user or not
                var isOwner = await _userOrganisationService.IsOwnerAsync(currentUser.Id, model.OrganisationId);
                if (!isOwner) return NotFound();

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
                    return View(model);
                }

                var organisation = await _organisationService.GetAsync(model.OrganisationId);

                // Create pivot record

                var organisationUser = new UserOrganisation
                {
                    OrganisationId = organisation.Id,
                    UserId = newUser.Id,
                    Role = OrganisationRole.Member
                };

                await _userOrganisationService.CreateAsync(organisationUser);

                return RedirectToRoute("organisation-index");
            }

            return View(model);
        }

        #endregion

        #region Board

        [HttpGet("{organisationId}/board", Name = "organisation-board")]
        public async Task<IActionResult> Board(int organisationId)
        {
            var currentUser = await _userService.GetUserAsync(User);

            
            return View();
        }

        #endregion 
    }
}
