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
    public class UsersDetailConfig : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.Property(x => x.FirstName).HasColumnName("First_Name").IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).HasColumnName("Last_Name").IsRequired().HasMaxLength(50);
            builder.Property(x => x.DateOfBirth).HasColumnName("Date_Of_Birth").HasColumnType("DateTime");
        }
    }
}
