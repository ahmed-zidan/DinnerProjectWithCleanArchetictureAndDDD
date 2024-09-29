using Dinner.Application.Authentication.Common;
using Dinner.Application.Errors;
using MediatR;
using OneOf;


namespace Dinner.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string FirstName, string LastName, string Email, string Password) :IRequest<OneOf<AuthenticationRes,ApiResponse>>;
}
