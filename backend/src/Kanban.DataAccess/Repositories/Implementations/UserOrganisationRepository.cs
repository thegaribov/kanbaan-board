using Kanban.Core.Entities;
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
    public class UserOrganisationRepository : IUserOrganisationRepository
    {
        private readonly KanbanContext _context;

        public UserOrganisationRepository(KanbanContext context)
        {
            _context = context;
        }

        public async Task<List<UserOrganisation>> GetAllAsync()
        {
            return await _context.UserOrganisations.ToListAsync();
        }

        public async Task<UserOrganisation> GetAsync(string userId, int organisationId)
        {
            return await _context.UserOrganisations
                .FirstOrDefaultAsync(uo => uo.UserId == userId && uo.OrganisationId == organisationId);
        }

        public async Task CreateAsync(UserOrganisation userOrganisation)
        {
            await _context.AddAsync(userOrganisation);
        }

        public async Task DeleteAsync(UserOrganisation userOrganisation)
        {
            _context.Remove(userOrganisation);
        }

        public async Task UpdateAsync(UserOrganisation userOrganisation)
        {
            _context.Update(userOrganisation);
        }
    }
}
