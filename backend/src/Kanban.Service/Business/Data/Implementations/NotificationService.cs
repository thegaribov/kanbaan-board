﻿using Kanban.Core.Entities;
using Kanban.Core.Enums.Ticket;
using Kanban.DataAccess.UnitOfWork.Abstracts;
using Kanban.Service.Business.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Service.Business.Data.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
