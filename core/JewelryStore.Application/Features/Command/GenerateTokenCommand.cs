﻿using JewelryStore.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Features.Command
{
    public class GenerateTokenCommand:IRequest<AutenticatedUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
