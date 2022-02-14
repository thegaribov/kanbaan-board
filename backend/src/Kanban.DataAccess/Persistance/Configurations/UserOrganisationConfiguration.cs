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
    //public class UserOrganisationConfiguration : IEntityTypeConfiguration<UserOrganisation>
    //{
    //    public void Configure(EntityTypeBuilder<UserOrganisation> builder)
    //    {
    //        #region PK

    //        builder.
    //            HasKey(uo => new { uo.UserId, uo.OrganisationId });

    //        builder
    //            .HasOne<User>(uo => uo.User)
    //            .WithMany(u => u.UserOrganisations)
    //            .HasForeignKey(uo => uo.UserId);

    //        builder
    //           .HasOne<Organisation>(uo => uo.Organisation)
    //           .WithMany(u => u.UserOrganisations)
    //           .HasForeignKey(uo => uo.OrganisationId);

    //        #endregion

    //        #region Role

    //        builder
    //          .Property(o => o.Role)
    //          .IsRequired(true);

    //        #endregion

    //        builder
    //            .ToTable("Organisations");
    //    }
    //}
}
