using JewelryStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Domain.Entities.Jewelry
{
    public class ProductDetail: BaseEntity
    {
        public int Size { get; set; }
        public string Model { get; set; }= string.Empty;
        public string Material { get; set; }=string.Empty;
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
