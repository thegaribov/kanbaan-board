using Kanban.Core.Entities;
using Kanban.DataAccess.UnitOfWork.Abstracts;
using Kanban.Service.Business.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Service.Business.Data.Implementations
{
    public class OrganisationService : IOrganisationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrganisationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Organisation>> GetAllAsync()
        {
            return await _unitOfWork.Organisations.GetAllAsync();
        }

        public async Task<Organisation> GetAsync(int id)
        {
            return await _unitOfWork.Organisations.GetAsync(id);
        }

        public async Task CreateAsync(Organisation organisation)
        {
            await _unitOfWork.Organisations.CreateAsync(organisation);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Organisation organisation)
        {
            await _unitOfWork.Organisations.UpdateAsync(organisation);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Organisation organisation)
        {
            await _unitOfWork.Organisations.DeleteAsync(organisation);
            await _unitOfWork.CommitAsync();
        }
        
    }
}
