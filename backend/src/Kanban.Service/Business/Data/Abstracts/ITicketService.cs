using Kanban.Core.Entities;
using Kanban.Core.Enums.Ticket;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Service.Business.Data.Abstracts
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllAsync();
        Task<Dictionary<TicketStatus, List<Ticket>>> GetAllGroupedByOrganisation(int organisationId);
        Task<Ticket> GetAsync(int id);
        Task<Ticket> GetByOrganisation(int ticketId, int organisationId);
        Task CreateAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(Ticket ticket);

    }
}
