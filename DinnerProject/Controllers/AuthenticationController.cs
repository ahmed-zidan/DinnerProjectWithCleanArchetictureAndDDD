using Dinner.Application.Errors;
using Dinner.Application.Services.Authentication;
using Dinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace Dinner.Api.Controllers
{
    
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterRequest model)
        {
            OneOf<AuthenticationRes, ApiResponse> res = _authenticationService.Register(model.FirstName, model.LastName, model.Email,
                model.Password);

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
        public IActionResult Login(LoginRequest model)
        {
            var res = _authenticationService.Login(model.Email,
                model.Password);

            return res.Match(
                success => Ok(getAuthUser(res.AsT0)),
                error => Problem(res.AsT1)
                );
           
        }

    }
}
