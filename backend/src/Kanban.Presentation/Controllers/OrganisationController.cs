using Kanban.Core.Entities;
using Kanban.Core.Enums.Organisation;
using Kanban.Core.Extensions.IdentityResult;
using Kanban.Core.Helpers.ActionResultMessage;
using Kanban.Presentation.ViewModels.Organisation;
using Kanban.Service.Business.Data.Abstracts;
using Kanban.Service.Infrastructure.ActionResultMessage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
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
        private readonly ITicketService _ticketService;
        private readonly ActionResultMessageService _actionResultMessageService;

        public OrganisationController(
            IUserService userService,
            IOrganisationService organisationService,
            IUserOrganisationService userOrganisationService,
            ITicketService ticketService)
        {
            _userService = userService;
            _organisationService = organisationService;
            _userOrganisationService = userOrganisationService;
            _ticketService = ticketService;
            _actionResultMessageService = new();
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
                var members = await _userOrganisationService.GetOrganisationMembersAsync(userOrganisation.OrganisationId);

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

                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Update, "Organisation", Url.RouteUrl("organisation-edit", new { id = organisation.Id })));

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

                //Action result message
                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetResultMessage(
                    ActionResultMessageType.Success, $"New member ({newUser.FullName} - {newUser.Email}) successfully added to organisation"));

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

            //Check whether current user takes part in organisation or not
            var isTakePartIn = await _userOrganisationService.IsTakePartInAsync(currentUser.Id, organisationId);
            if (!isTakePartIn) return NotFound();

            var organisation = await _organisationService.GetAsync(organisationId);


            var model = new BoardViewModel
            {
                OrganisationName = organisation.Name,
                OrganisationId = organisation.Id,
                GroupedTickets = await _ticketService.GetAllGroupedByOrganisation(organisationId),
                IsCurrentUserOwner = await _userOrganisationService.IsOwnerAsync(currentUser.Id, organisationId)
            };

            return View(model);
        }

        #endregion 

        #region VisitProfile

        [HttpGet("{organisationId}/visitProfile/{userId}", Name = "organisation-visitprofile")]
        public async Task<IActionResult> VisitProfile(int organisationId, string userId)
        {
            var targetUser = await _userService.FindByIdAsync(userId);
            var targetUserRole = await _userOrganisationService.GetUserRoleAsync(userId, organisationId);
            var organisation = await _organisationService.GetAsync(organisationId);

            if (targetUser == null || organisation == null) return NotFound();

            var model = new VisitProfileViewModel
            {
                User = targetUser,
                Organisation = organisation,
                Role = targetUserRole
            };

            return View(model);
        }

        #endregion 
    }
}
