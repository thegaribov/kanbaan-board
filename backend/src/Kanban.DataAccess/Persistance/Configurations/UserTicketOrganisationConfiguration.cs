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
    public class UserTicketConfiguration : IEntityTypeConfiguration<UserTicket>
    {
        public void Configure(EntityTypeBuilder<UserTicket> builder)
        {
            #region PK

            builder.
                HasKey(ut => new { ut.UserId, ut.TicketId });

            builder
                .HasOne<User>(ut => ut.User)
                .WithMany(u => u.UserTickets)
                .HasForeignKey(ut => ut.UserId);

            builder
               .HasOne<Ticket>(ut => ut.Ticket)
               .WithMany(u => u.UserTickets)
               .HasForeignKey(ut => ut.TicketId);

            #endregion

            builder
                .ToTable("UserTickets");
        }
    }
}
