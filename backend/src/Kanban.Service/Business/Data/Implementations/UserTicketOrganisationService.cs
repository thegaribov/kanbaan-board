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
    public class UserTicketOrganisationService : IUserTicketOrganisationService
    {
        private readonly IUnitOfWork _unitOfWork; 

        public UserTicketOrganisationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserTicketOrganisation>> GetAllAsync()
        {
            return await _unitOfWork.UserTicketOrganisations.GetAllAsync();
        }

        public async Task<UserTicketOrganisation> GetAsync(string userId, int ticketId, int organisationId)
        {
            return await _unitOfWork.UserTicketOrganisations.GetAsync(userId, ticketId, organisationId);
        }

     
        public async Task CreateAsync(UserTicketOrganisation userTicketOrganisation)
        {
            await _unitOfWork.UserTicketOrganisations.CreateAsync(userTicketOrganisation);
            await _unitOfWork.CommitAsync();
        }

      
        public async Task UpdateAsync(UserTicketOrganisation userTicketOrganisation)
        {
            await _unitOfWork.UserTicketOrganisations.UpdateAsync(userTicketOrganisation);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(UserTicketOrganisation userTicketOrganisation)
        {
            await _unitOfWork.UserTicketOrganisations.DeleteAsync(userTicketOrganisation);
            await _unitOfWork.CommitAsync();
        }

    }
}
