using Kanban.Core.Entities;
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
    public interface IUserTicketRepository
    {
        Task<List<UserTicket>> GetAllAsync();
        Task<List<UserTicket>> GetAllByTicketAsync(int ticketId);
        Task<List<string>> GetAllUsersIdsByTicketIdAsync(int ticketId);
        Task<UserTicket> GetAsync(string userId, int ticketId);
        Task CreateAsync(UserTicket userTicket);
        Task UpdateAsync(UserTicket userTicket);
        Task DeleteAsync(UserTicket userTicket);
        Task DeleteRangeAsync(List<UserTicket> userTickets);
        Task DeleteRangeByTicketAsync(int ticketId);
    }
}
