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

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest model)
        {
            
            OneOf<AuthenticationRes, ApiResponse> res = await _mediator.Send(new RegisterCommand(model.FirstName, model.LastName, model.Email,
                model.Password));

            return res.Match(
                 success => Ok(getAuthUser(res.AsT0)),
                 error => Problem(res.AsT1)
                 );
        }

        private AuthResponse getAuthUser(AuthenticationRes res)
        {
            return new AuthResponse
                        (
                            Email: res.user.Email,
                            FirstName: res.user.FirstName,
                            LastName: res.user.LastName,
                            Id: res.user.Id,
                            Token: res.Token
                        );
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            var res = await _mediator.Send(new LoginQuery(model.Email,
                model.Password));
            return res.Match(
                success => Ok(getAuthUser(res.AsT0)),
                error => Problem(res.AsT1)
                );
           
        }

    }
}
