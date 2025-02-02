﻿using Kanban.Core.Entities;
using Kanban.Core.Enums.NotifyEvent;
using Kanban.DataAccess.Persistance.Contexts;
using Kanban.DataAccess.Repositories.Abstracts;
using Kanban.DataAccess.Repositories.Implementations.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.DataAccess.Repositories.Implementations
{
    public class NotifyEventRepository : EFBaseRepository<NotifyEvent>, INotifyEventRepository
    {
        private readonly KanbanContext _context;

        public NotifyEventRepository(KanbanContext context)
            :base(context)
        {
            _context = context;
        }

        public async Task<NotifyEvent> GetByIdentifierAsync(NotifyIdentifier identifier)
        {
            return await _context.NotifyEvents.FirstOrDefaultAsync(ne => ne.NotifyFor == identifier);
        }
    }
}
