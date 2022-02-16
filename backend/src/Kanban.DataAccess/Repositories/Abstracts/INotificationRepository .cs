using Kanban.Core.Entities;
using Kanban.DataAccess.Abstracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.DataAccess.Repositories.Abstracts
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
    }
}
