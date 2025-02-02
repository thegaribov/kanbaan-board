﻿using Kanban.Core.Entities;
using Kanban.Core.Enums.Ticket;
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

        public async Task<Ticket> GetByOrganisation(int ticketId, int organisationId)
        {
            return await _unitOfWork.Tickets.GetByOrganisation(ticketId, organisationId);
        }

        public async Task<Ticket> GetWithOrganisationByOrganisation(int ticketId, int organisationId)
        {
            return await _unitOfWork.Tickets.GetWithOrganisationByOrganisation(ticketId, organisationId);
        }

        public async Task<Dictionary<TicketStatus, List<Ticket>>> GetAllGroupedByOrganisation(int organisationId)
        {
            return await _unitOfWork.Tickets.GetAllGroupedByOrganisation(organisationId);
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
