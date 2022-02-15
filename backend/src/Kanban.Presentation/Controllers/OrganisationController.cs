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
    }
}
