using Dinner.Application.Authentication.Common;
using Dinner.Application.Errors;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password):IRequest<OneOf<AuthenticationRes, ApiResponse>>;
    
}
