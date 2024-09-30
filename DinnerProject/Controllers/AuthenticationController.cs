using AutoMapper;
using Dinner.Application.Authentication.Commands.Register;
using Dinner.Application.Authentication.Common;
using Dinner.Application.Authentication.Queries.Login;
using Dinner.Application.Errors;
using Dinner.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace Dinner.Api.Controllers
{

    public class AuthenticationController : BaseController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest model)
        {
            var command = _mapper.Map<RegisterCommand>(model);
              
            OneOf<AuthenticationRes, ApiResponse> res = await _mediator.Send(command);

            return res.Match(
                 success => Ok( _mapper.Map< AuthResponse>(res.AsT0)),
                 error => Problem(res.AsT1)
                 );
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            var querey = _mapper.Map<LoginQuery>(model);
            var res = await _mediator.Send(querey);
            return res.Match(
                success => Ok(_mapper.Map<AuthResponse>(res.AsT0)),
                error => Problem(res.AsT1)
                );
           
        }

    }
}
