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
    public interface IOrganisationService
    {
        Task<List<Organisation>> GetAllAsync();
        Task<Organisation> GetAsync(int id);
        Task CreateAsync(Organisation organisation);
        Task UpdateAsync(Organisation organisation);
        Task DeleteAsync(Organisation organisation);
    }
}
