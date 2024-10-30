using JewelryStore.Application.Dtos;
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
    public class CreateUserCommand:IMapTo<Users>,IMapTo<UserDetail>,IRequest<AutenticatedUserDto>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
