﻿using JawelryStore.Persistance.DbConfigurations.Common;
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
    public class CartItemsConfig: EfBaseConfiguration<CartItems>
    {
        public override void Configure(EntityTypeBuilder<CartItems> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Quantity);

          
        }
    }
}