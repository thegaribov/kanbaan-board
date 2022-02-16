using Kanban.Core.Entities;
using Kanban.Core.Enums.NotifyEvent;
using Kanban.DataAccess.Abstracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.DataAccess.Repositories.Abstracts
{
    public interface INotifyEventRepository : IBaseRepository<NotifyEvent>
    {
        Task<NotifyEvent> GetByIdentifierAsync(NotifyIdentifier identifier);
    }
}
