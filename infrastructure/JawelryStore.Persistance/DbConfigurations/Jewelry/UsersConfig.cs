using JawelryStore.Persistance.DbConfigurations.Common;
using JewelryStore.Domain.Entities.Jewelry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace JawelryStore.Persistance.DbConfigurations.Jewelry
{
    public class UsersConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Email)
                   .IsUnique();
            builder.Property(x => x.Email).IsRequired();
           

            builder
               .HasMany(u => u.Reviews)
               .WithOne(r => r.Users)
               .HasForeignKey(r => r.UsersId);

            builder
               .HasMany(x => x.UsersRoles).WithOne(x => x.Users).HasForeignKey(x => x.UsersId);
            builder
                .HasOne(x => x.UserDetail).WithOne(r => r.Users).HasForeignKey<UserDetail>(x => x.UsersId);
        }
    }
}