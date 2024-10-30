using JewelryStore.Application.Dtos;
using JewelryStore.Application.Extensions;
using JewelryStore.Application.Helper;
using JewelryStore.Application.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Features.Command
{
    public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, AutenticatedUserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenerateTokenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AutenticatedUserDto> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetUserWithDetail(request.Email);
            if (user is null)
            {
                throw new JewelryStoreException("User is not found");
            }
            if ( !HashHelper.VerifyPasswordHash(request.Password, Convert.FromBase64String(user.PasswordHash), Convert.FromBase64String(user.PasswordSalt)))
            {
                throw new JewelryStoreException("Email or password is incorrect");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name , user.UserDetail.FirstName),
                new Claim(ClaimTypes.Surname , user.UserDetail.LastName),
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AutenticatedUserDto
            {
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
