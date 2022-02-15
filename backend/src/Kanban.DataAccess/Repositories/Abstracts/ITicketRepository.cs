using Kanban.Core.Entities;
using Kanban.Core.Enums.Ticket;
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
    public interface ITicketRepository : IBaseRepository<Ticket>
    {
        Task<Dictionary<TicketStatus, List<Ticket>>> GetAllGroupedByOrganisation(int organisationId);
        Task<Ticket> GetByOrganisation(int ticketId, int organisationId);
    }
}
