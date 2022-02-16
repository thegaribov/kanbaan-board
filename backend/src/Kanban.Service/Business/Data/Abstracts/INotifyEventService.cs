using Kanban.Core.Entities;
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
        Task CreateAsync(NotifyEvent notifyEvent);
        Task UpdateAsync(NotifyEvent notifyEvent);
    }
}
