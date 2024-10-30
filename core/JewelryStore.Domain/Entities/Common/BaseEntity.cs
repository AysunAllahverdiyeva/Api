using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Domain.Entities.Common
{
    public class BaseEntity
    {
        public int id { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set;}
       
        public int? CreatedId { get; set; }
        public int? UpdatedId { get; set;}
    }
}
