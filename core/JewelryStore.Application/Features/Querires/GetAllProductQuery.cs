﻿using JewelryStore.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Features.Querires
{
    public class GetAllProductQuery:IRequest<IEnumerable<ProductViewDto>>
    {
    }
}
