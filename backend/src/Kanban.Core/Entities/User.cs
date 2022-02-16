using Kanban.Core.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Core.Entities
{
    public class User : IdentityUser, IEntity, ICreatedAt, IUpdatedAt
    {
        public string FullName { get; set; }

        #region Date logging

        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion

        public ICollection<UserOrganisation> UserOrganisations { get; set; }
        public ICollection<UserTicket> UserTickets { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
