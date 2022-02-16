using Kanban.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Service.Business.Data.Abstracts
{
    public interface INotificationService
    {
        Task<List<Core.Entities.Notification>> GetAllAsync();
        Task<Core.Entities.Notification> GetAsync(int id);
        Task CreateAsync(Core.Entities.Notification notification);
        Task UpdateAsync(Core.Entities.Notification notification);
    }
}
