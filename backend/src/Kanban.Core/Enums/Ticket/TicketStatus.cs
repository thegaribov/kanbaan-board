using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Core.Enums.Ticket
{
    public enum TicketStatus : byte
    {
        [Display(Name = "Open")]
        Open = 0,

        [Display(Name = "In progress")]
        InProgress = 1,

        [Display(Name = "Completed")]
        Completed = 2,

        [Display(Name = "Done")]
        Done = 3,
    }
}
