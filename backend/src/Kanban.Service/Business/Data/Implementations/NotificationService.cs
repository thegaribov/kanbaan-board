using Kanban.Core.Entities;
using Kanban.Core.Enums.NotifyEvent;
using Kanban.Core.Enums.Ticket;
using Kanban.Core.Helpers.Notification;
using Kanban.DataAccess.UnitOfWork.Abstracts;
using Kanban.Service.Business.Data.Abstracts;
using Kanban.Service.Infrastructure.BackgroundTask.BackgroundTaskQueue.Abstracts;
using Kanban.Service.Notification.Email.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kanban.Service.Notification.Email.Abstracts.IEmailService;

namespace Kanban.Service.Business.Data.Implementations
{
    public partial class NotificationService : INotificationService
    {
        #region Business send methods

        public async Task<NotificationResult> SendTicketAssignedAsync(User toUser, Ticket assignedTicket)
        {
            var notification = await CreateAndGetAsync(toUser, assignedTicket, NotifyIdentifier.TicketAssignedToUser);
            var sendResult = await SendByIdAsync(notification.Id);

            await _unitOfWork.CommitAsync();

            return sendResult;
        }

        public void SendTicketAssignedInBackground(User toUser, Ticket assignedTicket)
        {
            _backgroundTaskQueue.EnqueueTask(async (serviceScopeFactory, cancellationToken) =>
            {
                // Get services
                using var scope = serviceScopeFactory.CreateScope();
                var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<NotificationService>>();

                try
                {
                    await notificationService.SendTicketAssignedAsync(toUser, assignedTicket);

                    logger.LogInformation($"[BT] [NotificationService] [{DateTime.UtcNow.ToString("dd/MM/yyy HH:mm:ss")}] Send task assigned notification completed successfully.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"[BT] [NotificationService] [{DateTime.UtcNow.ToString("dd/MM/yyy HH:mm:ss")}] Send task assigned notification completed unsuccessfully, exception occurred.");
                }
            });
        }

        #endregion


        #region Fundamental send methods

        private async Task<NotificationResult> SendByIdAsync(int id)
        {
            var notification = await GetAsync(id);
            if (notification == null) throw new Exception($"There isn't any notification for id: {id}");

            NotificationResult notificationResult = new();

            if (notification.NotifyEvent.IsActive)
            {
                if (notification.NotifyEvent.EmailEnabled)
                    notificationResult.EmailSent = await SendEmailAsync(notification);


                await UpdateContentAsync(notification);
            }


            return notificationResult;
        }

        private async Task<bool> SendEmailAsync(Core.Entities.Notification notification)
        {
            var toUser = await _userService.FindByIdAsync(notification.UserId);
            var emailSubject = await GetTextAsync(notification.NotifyEvent.EmailSubject, notification);
            var emailText = await GetTextAsync(notification.NotifyEvent.EmailText, notification);

            _content.EmailSubject = emailSubject;
            _content.EmailText = emailText;

            Message message = new Message(emailSubject, emailText, toUser.Email);

            return await _emailService.SendAsync(message);
        }

        #endregion

        #region Get text methods

        private async Task<string> GetTextAsync(string text, Core.Entities.Notification notification)
        {
            text = text.Replace("{{to_user_fullname}}", await GetUserFullNameAsync(notification));
            text = text.Replace("{{ticket_title}}", await GetTicketTitleAsync(notification));

            return text;
        }

        private async Task<string> GetUserFullNameAsync(Core.Entities.Notification notification)
        {
            var user = await _userService.FindByIdAsync(notification.UserId);
            return user?.FullName;
        }

        private async Task<string> GetTicketTitleAsync(Core.Entities.Notification notification)
        {
            var ticket = await _ticketService.GetAsync(notification.TicketId); 
            return ticket?.Title;
        }

        #endregion

        #region Notificaiton content

        private async Task UpdateContentAsync(Core.Entities.Notification notification)
        {
            string content = JsonConvert.SerializeObject(_content);
            notification.Extra = content;

            await UpdateAsync(notification);
        }

        #endregion
    }

    public partial class NotificationService : INotificationService
    {
        private NotificationContent _content;
        private readonly IUserService _userService;
        private readonly INotifyEventService _notifyEventService;
        private readonly IEmailService _emailService;
        private readonly IBackgroundTaskQueue _backgroundTaskQueue;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITicketService _ticketService;
        public NotificationService(
            IUserService userService,
            INotifyEventService notifyEventService,
            IEmailService emailService,
            IBackgroundTaskQueue backgroundTaskQueue,
            IUnitOfWork unitOfWork,
            ITicketService ticketService)
        {
            _userService = userService;
            _notifyEventService = notifyEventService;
            _emailService = emailService;
            _content = new();
            _backgroundTaskQueue = backgroundTaskQueue;
            _unitOfWork = unitOfWork;
            _ticketService = ticketService;
        }
   
        public async Task<List<Core.Entities.Notification>> GetAllAsync()
        {
            return await _unitOfWork.Notifications.GetAllAsync();
        }


        public async Task<Core.Entities.Notification> GetAsync(int id)
        {
            return await _unitOfWork.Notifications.GetAsync(id);
        }

        public async Task CreateAsync(Core.Entities.Notification notification)
        {
            await _unitOfWork.Notifications.CreateAsync(notification);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Core.Entities.Notification> CreateAndGetAsync(User user, Ticket ticket, NotifyIdentifier identifier)
        {
            var notifyEvent = await _notifyEventService.GetByIdentifierAsync(identifier);
            if (notifyEvent == null) throw new Exception($"There is no any notify event for {identifier}");

            var notification = new Core.Entities.Notification
            {
                UserId = user.Id,
                TicketId = ticket.Id,
                NotifyEventId = notifyEvent.Id,
            };

            await CreateAsync(notification);

            return notification;
        }

        public async Task UpdateAsync(Core.Entities.Notification notification)
        {
            await _unitOfWork.Notifications.UpdateAsync(notification);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Core.Entities.Notification notification)
        {
            await _unitOfWork.Notifications.DeleteAsync(notification);
            await _unitOfWork.CommitAsync();
        }
        
    }
}
