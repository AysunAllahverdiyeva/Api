using JewelryStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Domain.Entities.Jewelry
{
    public class SubCategory:BaseEntity
    {
        public string Value { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
