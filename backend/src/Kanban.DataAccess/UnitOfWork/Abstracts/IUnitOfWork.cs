using Kanban.Core.Entities;
using Kanban.DataAccess.Repositories.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.DataAccess.UnitOfWork.Abstracts
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IOrganisationRepository Organisations { get; }

        Task CommitAsync();
    }
}
