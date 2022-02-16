using Kanban.Core.Entities;
using Kanban.DataAccess.Persistance.Contexts;
using Kanban.DataAccess.Repositories.Abstracts;
using Kanban.DataAccess.Repositories.Implementations;
using Kanban.DataAccess.UnitOfWork.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.DataAccess.UnitOfWork.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly KanbanContext _context;

        public UnitOfWork(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager,
            KanbanContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }


        private IUserRepository user;
        public IUserRepository Users => user ??= new UserRepository(_context, _userManager, _signInManager, _roleManager);


        private IOrganisationRepository organisation;
        public IOrganisationRepository Organisations => organisation ??= new OrganisationRepository(_context);


        private IUserOrganisationRepository userOrganisation;
        public IUserOrganisationRepository UserOrganisations => userOrganisation ??= new UserOrganisationRepository(_context);


        private ITicketRepository ticket;
        public ITicketRepository Tickets => ticket ??= new TicketRepository(_context);


        private IUserTicketRepository userTicket;
        public IUserTicketRepository UserTickets => userTicket ??= new UserTicketRepository(_context);


        private INotifyEventRepository notifyEvent;
        public INotifyEventRepository NotifyEvents => notifyEvent ??= new NotifyEventRepository(_context);


        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
