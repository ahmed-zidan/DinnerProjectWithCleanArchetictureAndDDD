using AutoMapper;
using Dinner.Application.Authentication.Commands.Register;
using Dinner.Application.Authentication.Common;
using Dinner.Application.Authentication.Queries.Login;
using Dinner.Application.Menus.Commands.CreateMenu;
using Dinner.Application.Menus.Common;
using Dinner.Contracts.Authentication;
using Dinner.Contracts.Menu;
using Dinner.Domain.MenuAggregate;

namespace Dinner.Api.helper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<AuthenticationRes, AuthResponse>()
                .ForMember(x => x.Id, src => src.MapFrom(y => y.user.Id.Value))
                .ForMember(x => x.Email, src => src.MapFrom(y => y.user.Email))
                .ForMember(x => x.FirstName, src => src.MapFrom(y => y.user.FirstName))
                .ForMember(x => x.LastName, src => src.MapFrom(y => y.user.LastName))
                .ForMember(x => x.Token, src => src.MapFrom(y => y.Token));

            CreateMap<RegisterRequest, RegisterCommand>();
            CreateMap<LoginRequest, LoginQuery>();
            
            CreateMap<MenuSection, MenuSectionCommand>()
                .ForMember(x=>x.Name , src=>src.MapFrom(y=>y.Name))
                .ForMember(x => x.Description, src => src.MapFrom(y => y.Description));
            CreateMap<MenuItem, MenuItemCommand>();
            CreateMap<CreateMenuRequest, CreateMenuCommand>();

            
            CreateMap<Dinner.Domain.MenuAggregate.Entities.MenuItem, Dinner.Contracts.Menu.MenuItemRes>()
            .ForMember(x => x.Id, src => src.MapFrom(y => y.Id.Value));
            CreateMap<Dinner.Domain.MenuAggregate.Entities.MenuSection, Dinner.Contracts.Menu.MenuSectionRes>()
                .ForMember(x => x.Id, src => src.MapFrom(y => y.Id.Value))
                .ForMember(x => x.MenuItems, src => src.MapFrom(x => x.Items));


            CreateMap<Menu, MenuResponse>()
                .ForMember(x => x.Id, src => src.MapFrom(y => y.Id.Value))
                .ForMember(x=>x.AverageRating , src => src.MapFrom(y=>y.AverageRating.Value))
                .ForMember(x => x.HostId, src => src.MapFrom(y => y.HostId.Value))
                .ForMember(x => x.DinnerIds, src => src.MapFrom(y => y.MenuDinnerId.Select(x=>x.Value)))
                .ForMember(x => x.MenuReviewIds, src => src.MapFrom(y => y.MenuReviewIds.Select(x=>x.Value)));
              
                
        }
    }
}
