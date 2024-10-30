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
    public class ImagesConfig:EfBaseConfiguration<Images>
    {
        public override void Configure(EntityTypeBuilder<Images> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.ContentType).IsRequired().HasColumnName("Content_Type");

            builder
            .HasMany(ud => ud.UserDetails)
            .WithOne(i => i.Images)
            .HasForeignKey(i => i.ImagesId);
        }
    }
}
