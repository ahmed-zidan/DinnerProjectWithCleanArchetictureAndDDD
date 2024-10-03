using Dinner.Application.Authentication.Common;
using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Repositories;
using Dinner.Application.Errors;
using Dinner.Domain.UserAggregate;
using MediatR;
using OneOf;


namespace Dinner.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, OneOf<AuthenticationRes, ApiResponse>>
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterCommandHandler(IJWTTokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _unitOfWork = unitOfWork;
        }

        async Task<OneOf<AuthenticationRes, ApiResponse>> IRequestHandler<RegisterCommand, OneOf<AuthenticationRes, ApiResponse>>.Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork._userRepo.GetUserByEmailAsync(request.Email);
            if (user != null)
            {
                return new ApiResponse(400, "User already exist");
            }
            AppUser appUser = AppUser.CreateNew(request.FirstName, request.LastName, request.Email,
                request.Password);
           
            _unitOfWork._userRepo.AddUser(appUser);
            await _unitOfWork.SaveChangesAsync();

            Guid id = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(appUser);

            return new AuthenticationRes
            (
                appUser,
                token
            );
        }
    }
}
