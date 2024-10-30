using JawelryStore.Persistance.DbConfigurations.Common;
using JewelryStore.Domain.Entities.Jewelry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JawelryStore.Persistance.DbConfigurations.Jewelry
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.UserRole).IsRequired();

            builder.HasMany(x => x.UsersRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
        }
    }
     
}
