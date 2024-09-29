using Dinner.Application.Authentication.Common;
using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Repositories;
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
    public class loginQueryHandler : IRequestHandler<LoginQuery, OneOf<AuthenticationRes, ApiResponse>>
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IUnitOfWork _unitOfWork;
        public loginQueryHandler(IJWTTokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _unitOfWork = unitOfWork;
        }
        public async Task<OneOf<AuthenticationRes, ApiResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork._userRepo.GetUserByEmailAsync(request.Email);
            if (user == null || user.Password != request.Password)
            {
                return new ApiResponse(400, "Error in Email or password");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationRes
            (
                user,
                token
            );

        }
    }
}
