using JewelryStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Domain.Entities.Jewelry
{
    public class Images:BaseEntity
    {
        public int Url { get; set; }
        public string ContentType { get; set; }=string.Empty;
        public ICollection<UserDetail> UserDetails { get; set; }=new HashSet<UserDetail>();
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
