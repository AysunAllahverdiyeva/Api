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
    public class ProductDetailConfig:EfBaseConfiguration<ProductDetail>
    {
        public override void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Material).IsRequired();
            builder.Property(x=> x.Model).IsRequired();
            builder.Property(x => x.Size);
        }
    }
}
