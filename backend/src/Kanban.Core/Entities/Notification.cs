using Kanban.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Core.Entities
{
    public class Notification : IEntity, ICreatedAt
    {
        public int Id { get; set; }
        public string Extra { get; set; }

        #region NotifyEvent

        public NotifyEvent NotifyEvent { get; set; }
        public int NotifyEventId { get; set; }

        #endregion

        #region User

        public User User { get; set; }
        public string UserId { get; set; }

        #endregion

        #region Ticket

        public Ticket Ticket { get; set; }
        public int TicketId { get; set; }

        #endregion

        #region Date logs

        public DateTime CreatedAt { get; set; }

        #endregion
    }
}
