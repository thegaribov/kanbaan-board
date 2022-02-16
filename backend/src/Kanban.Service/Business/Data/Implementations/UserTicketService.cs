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
    public class UserTicketService : IUserTicketService
    {
        private readonly IUnitOfWork _unitOfWork; 

        public UserTicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserTicket>> GetAllAsync()
        {
            return await _unitOfWork.UserTickets.GetAllAsync();
        }

        public async Task<List<string>> GetAllUsersIdsByTicketIdAsync(int ticketId)
        {
            return await _unitOfWork.UserTickets.GetAllUsersIdsByTicketIdAsync(ticketId);
        }

        public async Task<UserTicket> GetAsync(string userId, int ticketId)
        {
            return await _unitOfWork.UserTickets.GetAsync(userId, ticketId);
        }

     
        public async Task CreateAsync(UserTicket userTicketOrganisation)
        {
            await _unitOfWork.UserTickets.CreateAsync(userTicketOrganisation);
            await _unitOfWork.CommitAsync();
        }

      
        public async Task UpdateAsync(UserTicket userTicketOrganisation)
        {
            await _unitOfWork.UserTickets.UpdateAsync(userTicketOrganisation);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(UserTicket userTicketOrganisation)
        {
            await _unitOfWork.UserTickets.DeleteAsync(userTicketOrganisation);
            await _unitOfWork.CommitAsync();
        }

    }
}
