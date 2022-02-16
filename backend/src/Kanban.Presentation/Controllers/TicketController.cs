using Kanban.Core.Entities;
using Kanban.Core.Enums.Organisation;
using Kanban.Core.Enums.Ticket;
using Kanban.Core.Extensions.IdentityResult;
using Kanban.Presentation.ViewModels.Organisation;
using Kanban.Presentation.ViewModels.Ticket;
using Kanban.Service.Business.Data.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
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
        private readonly IUserTicketService _userTicketService;
        private readonly INotificationService _notificationService;


        public TicketController(
            IUserService userService,
            IOrganisationService organisationService,
            IUserOrganisationService userOrganisationService,
            ITicketService ticketService,
            IUserTicketService userTicketService,
            INotificationService notificationService)
        {
            _userService = userService;
            _organisationService = organisationService;
            _userOrganisationService = userOrganisationService;
            _ticketService = ticketService;
            _userTicketService = userTicketService;
            _notificationService = notificationService;
        }

        #endregion

        #region Create

        [HttpGet("{organisationId}/create", Name = "ticket-create")]
        public async Task<IActionResult> Create(int organisationId, string status)
        {
            var currentUser = await _userService.GetUserAsync(User);

            //Check whether organisation belongs to current user or not
            var isOwner = await _userOrganisationService.IsOwnerAsync(currentUser.Id, organisationId);
            if (!isOwner) return NotFound();

            var organisation = await _organisationService.GetAsync(organisationId);

            Enum.TryParse(status, out TicketStatus providedStatus);

            var model = new TicketCreateViewModel
            {
                OrganisationId = organisation.Id,
                OrganisationName = organisation.Name,
                Users = await _userOrganisationService.GetAllUsersByOrganisationIdAsync(organisationId),
                Status = providedStatus
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

                //Add selected user to ticket
                foreach (var userId in model.UsersIds)
                {
                    var user = await _userService.FindByIdAsync(userId);

                    if (user != null)
                    {
                        var userTicket = new UserTicket
                        {
                            UserId = user.Id,
                            TicketId = newTicket.Id
                        };

                        await _userTicketService.CreateAsync(userTicket);

                        //Send assigned task notification
                        _notificationService.SendTicketAssignedInBackground(user, newTicket);
                    }
                }


                return RedirectToRoute("organisation-board", new { organisationId = model.OrganisationId });
            }

            return View(model);
        }

        #endregion

        #region Edit

        [HttpGet("{organisationId}/edit/{ticketId}", Name = "ticket-edit")]
        public async Task<IActionResult> Edit(int organisationId, int ticketId)
        {
            var currentUser = await _userService.GetUserAsync(User);

            //Check whether organisation belongs to current user or not
            var isOwner = await _userOrganisationService.IsOwnerAsync(currentUser.Id, organisationId);
            if (!isOwner) return NotFound();

            //Check tickets exist or not
            var ticket = await _ticketService.GetWithOrganisationByOrganisation(ticketId, organisationId);
            if (ticket == null) return NotFound();

            var model = new TicketEditViewModel
            {
                TicketId = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Deadline = ticket.Deadline,
                Status = ticket.Status,
                OrganisationId = ticket.Organisation.Id,
                OrganisationName = ticket.Organisation.Name,
                UsersIds = await _userTicketService.GetAllUsersIdsByTicketIdAsync(ticketId),
                Users = await _userOrganisationService.GetAllUsersByOrganisationIdAsync(organisationId),

            };

            return View(model);
        }

        [HttpPost("{organisationId}/edit/{ticketId}", Name = "ticket-edit")]
        public async Task<IActionResult> Edit(TicketEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userService.GetUserAsync(User);

                //Check whether organisation belongs to current user or not
                var isOwner = await _userOrganisationService.IsOwnerAsync(currentUser.Id, model.OrganisationId);
                if (!isOwner) return NotFound();

                //Check tickets exist or not
                var ticket = await _ticketService.GetByOrganisation(model.TicketId, model.OrganisationId);
                if (ticket == null) return NotFound();

                ticket.Title = model.Title;
                ticket.Description = model.Description;
                ticket.Deadline = model.Deadline;
                ticket.Status = model.Status;

                await _ticketService.UpdateAsync(ticket);

                // ===== Add selected user to ticket

                //1. Remove all related user-ticket records
                await _userTicketService.DeleteRangeByTicketAsync(ticket.Id);

                //2. Add selected users
                foreach (var userId in model.UsersIds)
                {
                    var user = await _userService.FindByIdAsync(userId);

                    if (user != null)
                    {
                        var userTicket = new UserTicket
                        {
                            UserId = user.Id,
                            TicketId = ticket.Id
                        };

                        await _userTicketService.CreateAsync(userTicket);
                    }
                }


                return RedirectToRoute("organisation-board", new { organisationId = model.OrganisationId });
            }

            return View(model);
        }

        #endregion

        #region Delete

        [HttpGet("{organisationId}/delete/{ticketId}", Name = "ticket-delete")]
        public async Task<IActionResult> Delete(int organisationId, int ticketId)
        {
            var currentUser = await _userService.GetUserAsync(User);

            //Check whether organisation belongs to current user or not
            var isOwner = await _userOrganisationService.IsOwnerAsync(currentUser.Id, organisationId);
            if (!isOwner) return NotFound();

            //Check tickets exist or not
            var ticket = await _ticketService.GetByOrganisation(ticketId, organisationId);
            if (ticket == null) return NotFound();

            await _ticketService.DeleteAsync(ticket);

            return RedirectToRoute("organisation-board", new { organisationId = organisationId });
        }


        #endregion
    }
}
