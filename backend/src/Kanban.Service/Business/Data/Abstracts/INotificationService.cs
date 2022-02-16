using Kanban.Core.Entities;
using Kanban.Core.Enums.NotifyEvent;
using Kanban.Core.Helpers.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Service.Business.Data.Abstracts
{
    public interface INotificationService
    {
        #region Business send methods

        Task<NotificationResult> SendTicketAssignedAsync(User toUser, Ticket assignedTicket);
        void SendTicketAssignedInBackground(User toUser, Ticket assignedTicket);

        #endregion

        Task<List<Core.Entities.Notification>> GetAllAsync();
        Task<Core.Entities.Notification> GetAsync(int id);
        Task CreateAsync(Core.Entities.Notification notification);
        Task<Core.Entities.Notification> CreateAndGetAsync(User user, Ticket ticket, NotifyIdentifier identifier);
        Task UpdateAsync(Core.Entities.Notification notification);
    }
}
