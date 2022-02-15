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
    public class UserTicketOrganisationConfiguration : IEntityTypeConfiguration<UserTicketOrganisation>
    {
        public void Configure(EntityTypeBuilder<UserTicketOrganisation> builder)
        {
            #region PK

            builder.
                HasKey(uto => new { uto.UserId, uto.OrganisationId, uto.TicketId });

            builder
                .HasOne<User>(uto => uto.User)
                .WithMany(u => u.UserTicketOrganisations)
                .HasForeignKey(uto => uto.UserId);

            builder
               .HasOne<Organisation>(uto => uto.Organisation)
               .WithMany(u => u.UserTicketOrganisations)
               .HasForeignKey(uto => uto.OrganisationId);

            builder
               .HasOne<Ticket>(uto => uto.Ticket)
               .WithMany(u => u.UserTicketOrganisations)
               .HasForeignKey(uto => uto.TicketId);

            #endregion

            builder
                .ToTable("UserTicketOrganisations");
        }
    }
}
