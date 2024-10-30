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
    public class SubCategoryConfig:EfBaseConfiguration<SubCategory>
    {
        public override void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Value);

            builder
            .HasOne(sc => sc.Category)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(sc => sc.CategoryId);


        }
    }
}
