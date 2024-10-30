using AutoMapper;
using FluentValidation;
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
    public class AddProductCommendHandler : IRequestHandler<AddProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AddProductCommand> validationRules;
        public AddProductCommendHandler(IUnitOfWork unitOfWork, IMapper mapper, AbstractValidator<AddProductCommand> validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.validationRules = validationRules;
        }
        public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var valid = await validationRules.ValidateAsync(request, cancellationToken);
            if (!valid.IsValid)
            {
                throw new ArgumentException("Command is not valid");
            }
            var productEntity = _mapper.Map<Product>(request);
            await _unitOfWork.ProductRepository.AddAsync(productEntity);
            await _unitOfWork.Commit();
        }
    }
}
