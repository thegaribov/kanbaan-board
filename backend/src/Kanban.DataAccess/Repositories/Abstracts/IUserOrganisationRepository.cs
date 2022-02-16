using Kanban.Core.Entities;
using Kanban.Core.Enums.Organisation;
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
    public interface IUserOrganisationRepository 
    {
        Task<List<UserOrganisation>> GetAllAsync();
        Task<List<User>> GetAllUsersByOrganisationIdAsync(int organisationId);
        Task<List<string>> GetAllUsersIdsByOrganisationIdAsync(int organisationId);
        Task<List<UserOrganisation>> GetAllWithUserAndOrganisationByUserAsync(string userId);
        Task<User> GetOrganisationOwnerByOrganisationAsync(int organisationId);
        Task<List<User>> GetOrganisationMembersAsync(int organisationId);
        Task<UserOrganisation> GetAsync(string userId, int organisationId);
        Task<OrganisationRole> GetUserRoleAsync(string userId, int organisationId);
        Task<bool> IsOwnerAsync(string userId, int organisationId);
        Task<bool> IsTakePartInAsync(string userId, int organisationId);
        Task CreateAsync(UserOrganisation userOrganisation);
        Task UpdateAsync(UserOrganisation userOrganisation);
        Task DeleteAsync(UserOrganisation userOrganisation);
    }
}
