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
    public class UserTicketOrganisation : IEntity, ICreatedAt, IUpdatedAt
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int OrganisationId { get; set; }
        public Organisation Organisation { get; set; }

        #region Date logging

        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion
    }
}
