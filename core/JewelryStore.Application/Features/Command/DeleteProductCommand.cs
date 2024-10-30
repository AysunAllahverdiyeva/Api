using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Features.Command
{
    public class DeleteProductCommand:IRequest
    {
        public int Id { get; set; }
       
    }
}
