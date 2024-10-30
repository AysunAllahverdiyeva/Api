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
    public class UsersRoleConfig : IEntityTypeConfiguration<UsersRole>
    {
        public void Configure(EntityTypeBuilder<UsersRole> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.UsersId });
        }
    }
}
