using JewelryStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Domain.Entities.Jewelry
{
    public class CartItems:BaseEntity
    {
        public int Quantity { get; set; }
        public int PorductId { get; set;}
        public Product Product { get; set;}
    }
}
