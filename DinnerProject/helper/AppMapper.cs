using AutoMapper;
using Dinner.Application.Authentication.Commands.Register;
using Dinner.Application.Authentication.Common;
using Dinner.Application.Authentication.Queries.Login;
using Dinner.Contracts.Authentication;

namespace Dinner.Api.helper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<AuthenticationRes, AuthResponse>()
                .ForMember(x => x.Id, src => src.MapFrom(y => y.user.Id))
                .ForMember(x => x.Email, src => src.MapFrom(y => y.user.Email))
                .ForMember(x => x.FirstName, src => src.MapFrom(y => y.user.FirstName))
                .ForMember(x => x.LastName, src => src.MapFrom(y => y.user.LastName))
                .ForMember(x => x.Token, src => src.MapFrom(y => y.Token));

            CreateMap<RegisterRequest, RegisterCommand>();
            CreateMap<LoginRequest, LoginQuery>();
        }
    }
}
