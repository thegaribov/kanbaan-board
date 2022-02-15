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
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _unitOfWork.Tickets.GetAllAsync();
        }


        public async Task<Ticket> GetAsync(int id)
        {
            return await _unitOfWork.Tickets.GetAsync(id);
        }

        public async Task CreateAsync(Ticket ticket)
        {
            await _unitOfWork.Tickets.CreateAsync(ticket);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            await _unitOfWork.Tickets.UpdateAsync(ticket);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Ticket ticket)
        {
            await _unitOfWork.Tickets.DeleteAsync(ticket);
            await _unitOfWork.CommitAsync();
        }
        
    }
}
