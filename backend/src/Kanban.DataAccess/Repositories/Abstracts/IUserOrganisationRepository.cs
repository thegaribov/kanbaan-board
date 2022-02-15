using Kanban.Core.Entities;
using Kanban.DataAccess.Abstracts.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.DataAccess.Repositories.Abstracts
{
    public interface IUserOrganisationRepository : IBaseRepository<UserOrganisation>
    {

    }
}
