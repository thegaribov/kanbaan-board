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

        public async Task<List<UserOrganisation>> GetAllWithUserAndOrganisationByUserAsync(string userId)
        {
            return await _context.UserOrganisations
                .Include(uo => uo.User)
                .Include(uo => uo.Organisation)
                .Where(uo => uo.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserOrganisation> GetAsync(string userId, int organisationId)
        {
            return await _context.UserOrganisations
                .FirstOrDefaultAsync(uo => uo.UserId == userId && uo.OrganisationId == organisationId);
        }

        public async Task<bool> IsOwnerAsync(string userId, int organisationId)
        {
            return await _context.UserOrganisations
                .AnyAsync(uo => uo.UserId == userId && uo.OrganisationId == organisationId && uo.Role == OrganisationRole.Owner);
        }

        public async Task<User> GetOrganisationOwnerByOrganisationAsync(int organisationId)
        {
            return (await _context.UserOrganisations
                .Include(uo => uo.User)
                .FirstOrDefaultAsync(
                    uo => uo.OrganisationId == organisationId && uo.Role == OrganisationRole.Owner))
                .User;
        }

        public async Task<List<string>> GetOrganisationMembersFullNameAsync(int organisationId)
        {
            return await _context.UserOrganisations
                        .Include(uo => uo.User)
                        .Where(uo => uo.OrganisationId == organisationId)
                        .Select(uo => uo.User.FullName)
                        .ToListAsync();
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
