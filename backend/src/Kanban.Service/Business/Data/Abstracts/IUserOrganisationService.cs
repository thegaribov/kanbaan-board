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
    public interface IUserOrganisationService
    {
        Task<List<UserOrganisation>> GetAllAsync();
        Task<List<UserOrganisation>> GetAllWithUserAndOrganisationByUserAsync(string userId);
        Task<UserOrganisation> GetAsync(string userId, int organisationId);
        Task<bool> IsOwnerAsync(string userId, int organisationId);
        Task<bool> IsTakePartInAsync(string userId, int organisationId);
        Task<User> GetOrganisationOwnerByOrganisationAsync(int organisationId);
        Task<List<string>> GetOrganisationMembersFullNameAsync(int organisationId);
        Task CreateAsync(UserOrganisation userOrganisation);
        Task UpdateAsync(UserOrganisation userOrganisation);
        Task DeleteAsync(UserOrganisation userOrganisation);
    }
}
