using Kanban.Core.Entities;
using Kanban.Core.Entities.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kanban.DataAccess.Persistance.Contexts
{
    public class KanbanContext : IdentityDbContext<User>
    {
        public KanbanContext(DbContextOptions<KanbanContext> options) : base(options) { }

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<UserOrganisation> UserOrganisations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        #region Date logs

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();

            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // for entities that implements ICreateTiming,
                // set CreatedAt to current UTC 
                if (entry.Entity is ICreatedAt createdEntity && entry.State == EntityState.Added)
                {
                    createdEntity.CreatedAt = utcNow;
                }

                if (entry.Entity is IUpdatedAt updatedEntity && entry.State == EntityState.Modified)
                {
                    // set the updated date to "now"
                    updatedEntity.UpdatedAt = utcNow;

                    if (entry.Entity is ICreatedAt _)
                    {
                        // mark property as "don't touch"
                        // we don't want to update on a Modify operation
                        entry.Property("CreatedAt").IsModified = false;
                    }

                }
            }
        }

        #endregion
    }
}
