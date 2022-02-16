using Kanban.Core.Entities;
using Kanban.Core.Enums.NotifyEvent;
using Kanban.DataAccess.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.DataAccess.Persistance.Seeding
{
    public static class DatabaseContextextSeed
    {
        public async static Task SeedNotifyEventsAsync(KanbanContext _context)
        {
            var notifyEvents = new List<NotifyEvent>
                {
                    new NotifyEvent
                    {
                        Label = "Account Activation",
                        NotifyFor = NotifyIdentifier.TicketAssignedToUser,
                        EmailEnabled = true,
                        EmailSubject = "Ticket assignment notification",
                        EmailText = "Hi {{to_user_fullname}}, ticket ({{ticket_title}}) assigned to you please check it",
                        IsActive = true
                    },
                };

            foreach (var notifyEvent in notifyEvents)
            {
                if (!_context.NotifyEvents.Any(ne => ne.NotifyFor == notifyEvent.NotifyFor))
                {
                    _context.NotifyEvents.Add(notifyEvent);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
