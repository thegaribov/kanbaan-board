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
    public interface IUserTicketOrganisationRepository
    {
        Task<List<UserTicketOrganisation>> GetAllAsync();
        Task<UserTicketOrganisation> GetAsync(string userId, int ticketId, int organisationId);
        Task CreateAsync(UserTicketOrganisation userTicketOrganisation);
        Task UpdateAsync(UserTicketOrganisation userTicketOrganisation);
        Task DeleteAsync(UserTicketOrganisation userTicketOrganisation);
    }
}
