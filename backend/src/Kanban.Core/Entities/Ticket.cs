using Kanban.Core.Entities.Common;
using Kanban.Core.Enums.Ticket;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Core.Entities
{
    public class Ticket : IEntity, ICreatedAt, IUpdatedAt
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TicketStatus Status { get; set; }

        #region Date logging

        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion

        public IList<UserTicketOrganisation> UserTicketOrganisations { get; set; }
    }
}
