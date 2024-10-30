using JawelryStore.Persistance.DbConfigurations.Common;
using JewelryStore.Domain.Entities.Jewelry;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JawelryStore.Persistance.DbConfigurations.Jewelry
{
    public class DesignersConfig:EfBaseConfiguration<Designers>
    {
        public override void Configure(EntityTypeBuilder<Designers> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).IsRequired();

            builder
           .HasMany(c => c.Products)
           .WithOne(p => p.Designers)
           .HasForeignKey(p => p.DesignersId);
        }
    }
}
