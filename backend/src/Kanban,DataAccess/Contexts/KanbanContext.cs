using Kanban.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.DataAccess.Contexts
{
    public class KanbanContext : IdentityDbContext<User, IdentityRole, string>
    {
        public KanbanContext(DbContextOptions<KanbanContext> options) : base(options) { }
    }
}
