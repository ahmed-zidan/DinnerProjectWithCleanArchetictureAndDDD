using Dinner.Application.Common.Interfaces.Repositories;
using Dinner.Application.Errors;
using Dinner.Application.Menus.Common;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.MenuAggregate.Entities;
using Dinner.Domain.MenuAggregate;
using MediatR;
using OneOf;


namespace Dinner.Application.Menus.Commands.CreateMenu
{
    public class CreateCommandHandler : IRequestHandler<CreateMenuCommand, OneOf<Menu, ApiResponse>>
    {
        private readonly IUnitOfWork _uow;
        public CreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public async Task<OneOf<Menu, ApiResponse>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = Menu.Create(
                name: request.Name,
                description: request.Description,
                hostId: HostId.Create(request.HostId),
                menuSections: request.MenuSections.ConvertAll(
                    x => MenuSection.Create(x.Name, x.Description,
                x.MenuItems.ConvertAll(y=>MenuItem.Create(y.Name,y.Description))))
                );

            await _uow._menuRepo.CreateMenuAsync(menu);
            await _uow.SaveChangesAsync();
            return menu;
        }
    }
}
