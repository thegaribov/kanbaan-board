using Kanban.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Service.Business.Data.Abstracts
{
    public interface IUserTicketOrganisationService
    {
        Task<List<UserTicketOrganisation>> GetAllAsync();
        Task<UserTicketOrganisation> GetAsync(string userId, int ticketId, int organisationId);
        Task CreateAsync(UserTicketOrganisation userTicketOrganisation);
        Task UpdateAsync(UserTicketOrganisation userTicketOrganisation);
        Task DeleteAsync(UserTicketOrganisation userTicketOrganisation);
    }
}
