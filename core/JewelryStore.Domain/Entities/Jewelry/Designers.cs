using JewelryStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Domain.Entities.Jewelry
{
    public class Designers:BaseEntity
    {
        public string Name { get; set; }=string.Empty;
        public ICollection<Product> Products { get; set; }=new HashSet<Product>();
    }
}
