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

        #region NavigationProperties

        public NotifyEvent NotifyEvent { get; set; }
        public int NotifyEventId { get; set; }

        #endregion

        #region Date logs

        public DateTime CreatedAt { get; set; }

        #endregion
    }
}
