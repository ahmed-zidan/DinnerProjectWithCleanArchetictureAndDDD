using Dinner.Domain.MenuAggregate;
using MediatR;

using OneOf;
using Dinner.Application.Errors;

namespace Dinner.Application.Menus.Queries.GetMenus
{
    public record GetMenusQuery : IRequest<OneOf<List<Menu> , ApiResponse>>;
}
