﻿using Kanban.DataAccess.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.DataAccess.Persistance.Seeding
{
    public static class AutomatedMigration
    {
        public static async Task MigrateAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<KanbanContext>();
            await context.Database.MigrateAsync();

            //Seed default notify event content, so in future we can edit them from staff panel
            await DatabaseContextextSeed.SeedNotifyEventsAsync(context);
        }
    }
}
