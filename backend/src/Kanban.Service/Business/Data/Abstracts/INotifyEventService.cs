using Kanban.Core.Entities;
using Kanban.Core.Enums.NotifyEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Service.Business.Data.Abstracts
{
    public interface INotifyEventService
    {
        Task<List<NotifyEvent>> GetAllAsync();
        Task<NotifyEvent> GetAsync(int id);
        Task<NotifyEvent> GetByIdentifierAsync(NotifyIdentifier identifier);
        Task CreateAsync(NotifyEvent notifyEvent);
        Task UpdateAsync(NotifyEvent notifyEvent);
    }
}
