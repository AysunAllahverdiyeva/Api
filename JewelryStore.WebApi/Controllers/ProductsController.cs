using JewelryStore.Application.Dtos;
using JewelryStore.Application.Features.Command;
using JewelryStore.Application.Features.Querires;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JewelryStore.WebApi;

namespace JewelryStore.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ApiControllerBase
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {

        }
            [HttpGet]
            [ActionName("products")]
            public async Task<ActionResult<ApiResponseModel<IEnumerable<ProductViewDto>>>> GetProductAsync()
            {
                var products = await _mediator.Send(new GetAllProductQuery());

                return await SuccessResult("Product data is selecte", products);
            }
      
            [HttpPost]
            [ActionName("products")]
            public async Task<ActionResult<ApiResponseModel<string>>> AddProducts(AddProductCommand command)
            {
                await _mediator.Send(command);
                return await SuccessResult<string>("Product added succesfully");
            }

        [HttpPut]
        [ActionName("products")]
        public async Task<ActionResult<ApiResponseModel<ProductViewDto>>> UpdateProduct(UpdateProductCommand command)
        {
          
            var product = await _mediator.Send(command);
            return await SuccessResult("Product updated succesfully",product);
        }

    }


}
