using AutoMapper;
using FluentValidation;
using JewelryStore.Application.Dtos;
using JewelryStore.Application.Interfaces;
using JewelryStore.Domain.Entities.Jewelry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JewelryStore.Application.Features.Command
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductViewDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<UpdateProductCommand> _validationRules;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, AbstractValidator<UpdateProductCommand> validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;     
        }

        public async Task<ProductViewDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            
            var validationResult = _validationRules.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            // Mehsul bazada id ile tapilir
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ArgumentException($"Product with ID {request.Id} was not found.");
            }

            // Guncellenme edilir
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Color = request.Color;
            product.CategoryId = request.CategoryId;
            product.DesignersId = request.DesignersId;
            product.ProductDetailid = request.ProductDetailid;
            product.UpdatedDate = DateTime.UtcNow;

            // Deyisiklikler qeyd edilir
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.Commit();

            // Güncellenmiş mehsul DTO'ya map edilir
            return _mapper.Map<ProductViewDto>(product);
        }
    }


}
