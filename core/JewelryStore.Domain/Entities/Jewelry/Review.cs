
using JewelryStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Domain.Entities.Jewelry
{
    public class Review:BaseEntity
    {
        public int Point { get; set; }
        public string Comment { get; set; }=string.Empty;
        public int ProductId { get; set; }
        public int UsersId { get; set; }
        public Users Users { get; set; }
    }
}
