using AutoMapper;
using JewelryStore.Application.Dtos;
using JewelryStore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Features.Querires
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ProductViewDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
          var products= await _unitOfWork.ProductRepository.GetAllAsync();
          return _mapper.Map<IEnumerable<ProductViewDto>>(products);
        }
    }
}
