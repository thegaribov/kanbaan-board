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
        Task<UserOrganisation> GetAsync(string userId, int organisationId);
        Task CreateAsync(UserOrganisation userOrganisation);
        Task UpdateAsync(UserOrganisation userOrganisation);
        Task DeleteAsync(UserOrganisation userOrganisation);
    }
}
