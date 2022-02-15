using Kanban.Core.Entities;
using Kanban.Core.Enums.Organisation;
using Kanban.DataAccess.Persistance.Contexts;
using Kanban.DataAccess.Repositories.Abstracts;
using Kanban.DataAccess.Repositories.Implementations.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.DataAccess.Repositories.Implementations
{
    public class UserTicketOrganisationRepository : IUserTicketOrganisationRepository
    {
        private readonly KanbanContext _context;

        public UserTicketOrganisationRepository(KanbanContext context)
        {
            _context = context;
        }

        public async Task<List<UserTicketOrganisation>> GetAllAsync()
        {
            return await _context.UserTicketOrganisations.ToListAsync();
        }

        public async Task<UserTicketOrganisation> GetAsync(string userId, int ticketId, int organisationId)
        {
            return await _context.UserTicketOrganisations
                .FirstOrDefaultAsync(uto => uto.UserId == userId && uto.TicketId == ticketId && uto.OrganisationId == organisationId);
        }

        public async Task CreateAsync(UserTicketOrganisation userOrganisation)
        {
            await _context.AddAsync(userOrganisation);
        }

        public async Task DeleteAsync(UserTicketOrganisation userOrganisation)
        {
            _context.Remove(userOrganisation);
        }

        public async Task UpdateAsync(UserTicketOrganisation userOrganisation)
        {
            _context.Update(userOrganisation);
        }
    }
}
