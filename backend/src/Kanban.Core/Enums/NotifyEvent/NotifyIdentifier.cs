using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Core.Enums.NotifyEvent
{
    public enum NotifyIdentifier
    {
        [Display(Name = "Ticket assigned to user")]
        TicketAssignedToUser = 1,
    }
}
