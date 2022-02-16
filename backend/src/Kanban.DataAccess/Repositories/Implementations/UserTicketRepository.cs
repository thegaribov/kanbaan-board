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
    public class UserTicketRepository : IUserTicketRepository
    {
        private readonly KanbanContext _context;

        public UserTicketRepository(KanbanContext context)
        {
            _context = context;
        }

        public async Task<List<UserTicket>> GetAllAsync()
        {
            return await _context.UserTickets.ToListAsync();
        }

        public async Task<List<string>> GetAllUsersIdsByTicketIdAsync(int ticketId)
        {
            return await _context.UserTickets
                .Where(ut => ut.TicketId == ticketId)
                .Select(ut => ut.User.Id)
                .ToListAsync();
        }

        public async Task<UserTicket> GetAsync(string userId, int ticketId)
        {
            return await _context.UserTickets
                .FirstOrDefaultAsync(uto => uto.UserId == userId && uto.TicketId == ticketId);
        }

        public async Task CreateAsync(UserTicket userOrganisation)
        {
            await _context.AddAsync(userOrganisation);
        }

        public async Task DeleteAsync(UserTicket userOrganisation)
        {
            _context.Remove(userOrganisation);
        }

        public async Task UpdateAsync(UserTicket userOrganisation)
        {
            _context.Update(userOrganisation);
        }
    }
}
