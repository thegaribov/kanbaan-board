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
    public class NotifyEventConfiguration : IEntityTypeConfiguration<NotifyEvent>
    {
        public void Configure(EntityTypeBuilder<NotifyEvent> builder)
        {
            #region Label

            builder
              .Property(o => o.Label)
              .IsRequired(true);

            #endregion

            #region IsActive

            builder
              .Property(o => o.IsActive)
              .IsRequired(true);

            #endregion

            #region NotifyFor

            builder
              .Property(o => o.NotifyFor)
              .IsRequired(true);

            #endregion

            #region EmailEnabled

            builder
              .Property(o => o.EmailEnabled)
              .IsRequired(true);

            #endregion

            #region EmailSubject

            builder
              .Property(o => o.EmailSubject)
              .IsRequired(true);

            #endregion

            #region EmailText

            builder
              .Property(o => o.EmailText)
              .IsRequired(true);

            #endregion

            builder
                .ToTable("NotifyEvents");
        }
    }
}
