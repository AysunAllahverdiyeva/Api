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
    public class ReviewConfig:EfBaseConfiguration<Review>
    {
        public override void Configure(EntityTypeBuilder<Review> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Comment);
            builder.Property(x => x.Point).HasColumnType("integer");

          


        }
    }
}
