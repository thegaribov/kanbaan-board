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
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            #region NotifyEvent

            builder
                .HasOne<NotifyEvent>(n => n.NotifyEvent)
                .WithMany(ne => ne.Notifications)
                .HasForeignKey(n => n.NotifyEventId);

            #endregion

            builder
                .ToTable("Notifications");
        }
    }
}
