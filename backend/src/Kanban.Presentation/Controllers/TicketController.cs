using Kanban.Core.Entities;
using Kanban.Core.Enums.Organisation;
using Kanban.Core.Extensions.IdentityResult;
using Kanban.Presentation.ViewModels.Organisation;
using Kanban.Presentation.ViewModels.Ticket;
using Kanban.Service.Business.Data.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Presentation.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class TicketController : Controller
    {
        #region ctor

        private readonly IUserService _userService;
        private readonly IOrganisationService _organisationService;
        private readonly IUserOrganisationService _userOrganisationService;
        private readonly ITicketService _ticketService;

        public TicketController(
            IUserService userService,
            IOrganisationService organisationService,
            IUserOrganisationService userOrganisationService,
            ITicketService ticketService)
        {
            _userService = userService;
            _organisationService = organisationService;
            _userOrganisationService = userOrganisationService;
            _ticketService = ticketService;
        }

        #endregion

        #region Create

        [HttpGet("{organisationId}/create", Name = "ticket-create")]
        public async Task<IActionResult> Create(int organisationId)
        {
            var currentUser = await _userService.GetUserAsync(User);

            //Check whether organisation belongs to current user or not
            var isOwner = await _userOrganisationService.IsOwnerAsync(currentUser.Id, organisationId);
            if (!isOwner) return NotFound();

            var organisation = await _organisationService.GetAsync(organisationId);

            var model = new TicketCreateViewModel
            {
                OrganisationId = organisation.Id,
                OrganisationName = organisation.Name
            };

            return View(model);
        }

        [HttpPost("{organisationId}/create", Name = "ticket-create")]
        public async Task<IActionResult> Create(TicketCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userService.GetUserAsync(User);

                //Check whether organisation belongs to current user or not
                var isOwner = await _userOrganisationService.IsOwnerAsync(currentUser.Id, model.OrganisationId);
                if (!isOwner) return NotFound();

                var newTicket = new Ticket
                {
                    Title = model.Title,
                    Description = model.Description,
                    Deadline = model.Deadline,
                    OrganisationId = model.OrganisationId,
                    Status = model.Status,
                };

                await _ticketService.CreateAsync(newTicket);


                return RedirectToRoute("organisation-board", new { organisationId = model.OrganisationId });
            }

            return View(model);
        }

        #endregion
    }
}
