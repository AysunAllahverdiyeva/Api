using JewelryStore.Application.Dtos;
using JewelryStore.Application.Features.Command;
using JewelryStore.Application.Features.Querires;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using JewelryStore.WebApi;
using JewelryStore.WebApi;

namespace JewelryStore.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        public AuthController(IMediator mediator) : base(mediator)
        {

        }
        [HttpPost]
        [ActionName("SignUp")]
        public async Task<ActionResult<ApiResponseModel<AutenticatedUserDto>>> Register(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return await SuccessResult("Token generated successfully", result);
        }

        [HttpPost]
        [ActionName("SignIn")]
        public async Task<ActionResult<ApiResponseModel<AutenticatedUserDto>>> Login(GenerateTokenCommand command)
        {
            var result = await _mediator.Send(command);

            return await SuccessResult("Token generated successfully", result);
        }


         

    }
}
