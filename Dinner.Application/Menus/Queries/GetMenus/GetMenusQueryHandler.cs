using Dinner.Application.Common.Interfaces.Repositories;
using Dinner.Application.Errors;
using Dinner.Domain.MenuAggregate;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Menus.Queries.GetMenus
{
    public class GetMenusQueryHandler : IRequestHandler<GetMenusQuery, OneOf<List<Menu>, ApiResponse>>
    {
        private readonly IUnitOfWork _uow;
        public GetMenusQueryHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public async Task<OneOf<List<Menu>, ApiResponse>> Handle(GetMenusQuery request, CancellationToken cancellationToken)
        {
            var menus = await _uow._menuRepo.GetMenusAsync();
            return menus;
        }
    }
}
