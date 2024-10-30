using JewelryStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Domain.Entities.Jewelry
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }=string.Empty;
        public decimal Price { get; set; } 
        public string Color { get; set; }= string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DesignersId { get; set; }
        public Designers Designers { get; set; }
        public int ProductDetailid { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Images> Images { get; set; }=new HashSet<Images>();
        public ICollection<CartItems> CartItems { get; set; }= new HashSet<CartItems>();
        
        
        

    }
}
