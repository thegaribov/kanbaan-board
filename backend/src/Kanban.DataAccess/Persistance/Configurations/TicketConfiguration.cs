using Kanban.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.DataAccess.Persistance.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            #region Title

            builder
              .Property(t => t.Title)
              .IsRequired(true);

            #endregion

            #region Organisation

            builder
                .HasOne<Organisation>(t => t.Organisation)
                .WithMany(o => o.Tickets)
                .HasForeignKey(t => t.OrganisationId);

            #endregion

            #region Description

            builder
              .Property(t => t.Description)
              .IsRequired(true);

            #endregion

            #region Deadline

            builder
              .Property(t => t.Deadline)
              .IsRequired(true);

            #endregion

            #region Status

            builder
              .Property(t => t.Status)
              .IsRequired(true);

            #endregion

            builder
                .ToTable("Tickets");
        }
    }
}
