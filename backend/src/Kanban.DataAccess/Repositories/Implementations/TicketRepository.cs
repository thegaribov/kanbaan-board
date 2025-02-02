﻿using Kanban.Core.Entities;
using Kanban.Core.Enums.Ticket;
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
    public class TicketRepository : EFBaseRepository<Ticket>, ITicketRepository
    {
        private readonly KanbanContext _context;

        public TicketRepository(KanbanContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Ticket> GetByOrganisation(int ticketId, int organisationId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId && t.OrganisationId == organisationId);
        }

        public async Task<Ticket> GetWithOrganisationByOrganisation(int ticketId, int organisationId)
        {
            return await _context.Tickets
                .Include(t => t.Organisation)
                .FirstOrDefaultAsync(t => t.Id == ticketId && t.OrganisationId == organisationId);
        }

        public async Task<Dictionary<TicketStatus, List<Ticket>>> GetAllGroupedByOrganisation(int organisationId)
        {
            return (await _context.Tickets
                        .Where(t => t.OrganisationId == organisationId)
                        .Include(t => t.UserTickets)
                        .ThenInclude(ut => ut.User)
                        .ToListAsync())
                        .GroupBy(t => t.Status)
                        .ToDictionary(t => t.Key, t => t.ToList());
        }
    }
}
