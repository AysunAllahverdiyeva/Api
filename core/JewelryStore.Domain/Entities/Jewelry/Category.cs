using JewelryStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Domain.Entities.Jewelry
{
    public class Category:BaseEntity
    {
        public string Value { get; set; }
        public ICollection<Product> Products { get; set; }=new HashSet<Product>();
        public ICollection<SubCategory> SubCategories { get; set; }= new HashSet<SubCategory>();
    }
}
