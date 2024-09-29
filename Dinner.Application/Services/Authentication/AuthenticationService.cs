using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Repositories;
using Dinner.Application.Errors;
using Dinner.Domain.Entities;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IUnitOfWork _unitOfWork;
        public AuthenticationService(IJWTTokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _unitOfWork = unitOfWork;
        }

        public OneOf<AuthenticationRes,ApiResponse> Login(string Email, string Password)
        {
            var user = _unitOfWork._userRepo.GetUserByEmail(Email);
            if (user == null || user.Password != Password) {
                return new ApiResponse(400,"Error in Email or password");
            }
           
            var token = _jwtTokenGenerator.GenerateToken(user);
            
            return new AuthenticationRes
            (
                user,
                token
            );

        }

        public OneOf<AuthenticationRes,ApiResponse> Register(string FirstName, string LastName, string Email, string Password)
        {
            var user = _unitOfWork._userRepo.GetUserByEmail(Email);
            if (user != null)
            {
                return new ApiResponse(400, "User already exist");
            }
            AppUser appUser = new AppUser()
            {
                Email = Email,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName
            };
            _unitOfWork._userRepo.AddUser(appUser);
            _unitOfWork.SaveChangesAsync();

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
