using Dinner.Application.Errors;
using Dinner.Application.Menus.Common;
using Dinner.Domain.MenuAggregate;
using MediatR;
using OneOf;

namespace Dinner.Application.Menus.Commands.CreateMenu
{
   

    public sealed class CreateMenuCommand:IRequest<OneOf<Menu, ApiResponse>>
    {
         public string HostId                           {set;get;}
         public string Name                             {set;get;}
         public string Description                      {set;get;}
         public List<MenuSectionCommand> MenuSections { set; get; }
}
    public sealed class MenuSectionCommand
    {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<MenuItemCommand> MenuItems { get; set; }
}

public sealed class MenuItemCommand
    {
    public string Name { get; set; }
    public string Description { get; set; }
}
      
}
