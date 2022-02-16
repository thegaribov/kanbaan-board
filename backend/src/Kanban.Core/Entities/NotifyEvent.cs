using Kanban.Core.Entities.Common;
using Kanban.Core.Enums.NotifyEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Core.Entities
{
    public class NotifyEvent : IEntity, ICreatedAt, IUpdatedAt
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public bool IsActive { get; set; }
        public NotifyIdentifier NotifyFor { get; set; }

        #region Email

        public bool EmailEnabled { get; set; }
        public string EmailSubject { get; set; }
        public string EmailText { get; set; }

        #endregion

        #region Date logs

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}
