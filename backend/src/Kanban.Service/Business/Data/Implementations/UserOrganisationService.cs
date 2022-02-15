using Kanban.Core.Entities;
using Kanban.DataAccess.Persistance.Contexts;
using Kanban.DataAccess.UnitOfWork.Abstracts;
using Kanban.Service.Business.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Service.Business.Data.Implementations
{
    public class UserOrganisationService : IUserOrganisationService
    {
        private readonly IUnitOfWork _unitOfWork; 

        public UserOrganisationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserOrganisation>> GetAllAsync()
        {
            return await _unitOfWork.UserOrganisations.GetAllAsync();
        }

        public async Task<List<UserOrganisation>> GetAllWithUserAndOrganisationByUserAsync(string userId)
        {
            return await _unitOfWork.UserOrganisations.GetAllWithUserAndOrganisationByUserAsync(userId);
        }

        public async Task<UserOrganisation> GetAsync(string userId, int organisationId)
        {
            return await _unitOfWork.UserOrganisations.GetAsync(userId, organisationId);
        }

        public async Task<bool> IsOwnerAsync(string userId, int organisationId)
        {
            return await _unitOfWork.UserOrganisations.IsOwnerAsync(userId, organisationId);
        }

        public async Task<User> GetOrganisationOwnerByOrganisationAsync(int organisationId)
        {
            return await _unitOfWork.UserOrganisations.GetOrganisationOwnerByOrganisationAsync(organisationId);
        }

        public async Task<List<string>> GetOrganisationMembersFullNameAsync(int organisationId)
        {
            return await _unitOfWork.UserOrganisations.GetOrganisationMembersFullNameAsync(organisationId);
        }

        public async Task CreateAsync(UserOrganisation userOrganisation)
        {
            await _unitOfWork.UserOrganisations.CreateAsync(userOrganisation);
            await _unitOfWork.CommitAsync();
        }

      
        public async Task UpdateAsync(UserOrganisation userOrganisation)
        {
            await _unitOfWork.UserOrganisations.UpdateAsync(userOrganisation);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(UserOrganisation userOrganisation)
        {
            await _unitOfWork.UserOrganisations.DeleteAsync(userOrganisation);
            await _unitOfWork.CommitAsync();
        }

    }
}
