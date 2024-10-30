using JewelryStore.Application.Mappers;
using JewelryStore.Domain.Entities.Jewelry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Features.Command
{
    public class AddProductCommand:IMapTo<Product>, IRequest
    {
        public string Name { get; set; } 
        public decimal Price { get; set; }
        public string Color { get; set; } 
        public string Description { get; set; } 
        public int DesignersId { get; set; }
        public int ProductDetailid { get; set; }
        public int CategoryId { get; set; }

    }
}
