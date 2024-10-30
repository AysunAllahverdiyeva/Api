using AutoMapper;
using JewelryStore.Application.Dtos;
using JewelryStore.Application.Helper;
using JewelryStore.Application.Interfaces;
using JewelryStore.Domain.Entities.Jewelry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Features.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, AutenticatedUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public CreateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        public async Task<AutenticatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Users>(request);
            user.UserDetail = _mapper.Map<UserDetail>(request);

            byte[] passwordHash, passwordSalt;

            HashHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = Convert.ToBase64String(passwordHash);
            user.PasswordSalt = Convert.ToBase64String(passwordSalt);

            await _unitOfWork.UserRepository.AddUsers(user);
            await _unitOfWork.Commit();

            return await _mediator.Send(new GenerateTokenCommand
            {
                Email = request.Email,
                Password = request.Password
            }, cancellationToken);
        }
    }
}
