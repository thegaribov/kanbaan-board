using Kanban.Core.Entities;
using Kanban.Core.Enums.NotifyEvent;
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
    public class NotifyEventService : INotifyEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        public NotifyEventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
   
        public async Task<List<NotifyEvent>> GetAllAsync()
        {
            return await _unitOfWork.NotifyEvents.GetAllAsync();
        }

        public async Task<NotifyEvent> GetByIdentifierAsync(NotifyIdentifier identifier)
        {
            return await _unitOfWork.NotifyEvents.GetByIdentifierAsync(identifier);
        }

        public async Task<NotifyEvent> GetAsync(int id)
        {
            return await _unitOfWork.NotifyEvents.GetAsync(id);
        }

        public async Task CreateAsync(NotifyEvent notifyEvent)
        {
            await _unitOfWork.NotifyEvents.CreateAsync(notifyEvent);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(NotifyEvent notifyEvent)
        {
            await _unitOfWork.NotifyEvents.UpdateAsync(notifyEvent);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(NotifyEvent notifyEvent)
        {
            await _unitOfWork.NotifyEvents.DeleteAsync(notifyEvent);
            await _unitOfWork.CommitAsync();
        }
        
    }
}
