using Kanban.Core.Entities.Common;
using Kanban.Core.Enums.Organisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Core.Entities
{
    public  class UserOrganisation : IEntity, ICreatedAt, IUpdatedAt
    {
        public string UserId { get; set; }
        public User User { get; set; }


        public int OrganisationId { get; set; }
        public Organisation Organisation { get; set; }

        public OrganisationRole Role { get; set; }

        #region Date logging

        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion
    }
}
