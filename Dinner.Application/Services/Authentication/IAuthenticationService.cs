using Dinner.Application.Errors;
using OneOf;


namespace Dinner.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        OneOf<AuthenticationRes, ApiResponse> Register(string FirstName,
        string LastName,
        string Email,
        string Password);

        OneOf<AuthenticationRes, ApiResponse> Login(string Email,string Password);

    }
}
