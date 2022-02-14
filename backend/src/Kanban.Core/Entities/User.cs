﻿using Kanban.Core.Entities.Common;
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

        public IList<UserOrganisation> UserOrganisations { get; set; }
    }
}
