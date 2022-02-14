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
    public class OrganisationConfiguration : IEntityTypeConfiguration<Organisation>
    {
        public void Configure(EntityTypeBuilder<Organisation> builder)
        {
            #region Name

            builder
              .Property(o => o.Name)
              .IsRequired(true);

            #endregion

            #region PhoneNumber

            builder
              .Property(o => o.PhoneNumber)
              .IsRequired(true);

            #endregion

            #region Address

            builder
              .Property(o => o.Address)
              .IsRequired(true);

            #endregion



            builder
                .ToTable("Organisations");
        }
    }
}
