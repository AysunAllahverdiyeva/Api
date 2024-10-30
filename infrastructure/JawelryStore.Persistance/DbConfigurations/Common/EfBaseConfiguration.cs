using JewelryStore.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JawelryStore.Persistance.DbConfigurations.Common
{
    public class EfBaseConfiguration<T>: IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(k => k.id);

            builder.Property(p => p.id).HasColumnName("Id").UseIdentityColumn();
            builder.Property(p => p.CreatedDate).HasColumnName("CreatedDateTime").IsRequired(false);
            builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDateTime").IsRequired(false); ;
            builder.Property(p => p.CreatedId).HasColumnName("Created_Id").IsRequired(false); ;
            builder.Property(p => p.UpdatedId).HasColumnName("Updeted_Id").IsRequired(false); ;

        }
    }


}
