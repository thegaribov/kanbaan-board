using Kanban.Core.Enums.Ticket;
using System.Collections.Generic;

namespace Kanban.Presentation.ViewModels.Organisation
{
    public class BoardViewModel
    {
        public int OrganisationId { get; set; }
        public string OrganisationName { get; set; }
        public bool IsCurrentUserOwner { get; set; }
        public Dictionary<TicketStatus, List<Core.Entities.Ticket>> GroupedTickets { get; set; }
    }
}
