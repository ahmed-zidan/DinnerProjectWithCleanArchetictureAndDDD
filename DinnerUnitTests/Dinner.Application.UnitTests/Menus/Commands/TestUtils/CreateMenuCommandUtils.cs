using Dinner.Application.Menus.Commands.CreateMenu;
using Dinner.Domain.MenuAggregate;
using Dinner.Domain.MenuAggregate.Entities;
using DinnerUnitTests.TestUtils.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerUnitTests.Dinner.Application.UnitTests.Menus.Commands.TestUtils
{
    public static class CreateMenuCommandUtils
    {

    public static CreateMenuCommand CreateCommand(List<MenuSectionCommand>?sections = null) => new CreateMenuCommand()
        {
            Name = Constants.Menu.Name,
            Description = Constants.Menu.Description,
            HostId = Constants.Host.Id.ToString(),
            MenuSections = sections ??  getMenuSections(4)
        };

        public static List<MenuSectionCommand> getMenuSections(int count = 1,
            List<MenuItemCommand>? items = null)
        {
            return Enumerable.Range(0, count)
                .Select(i => new MenuSectionCommand()
                {
                    Description = Constants.Menu.SectionNameFromIndex(i),
                    Name = Constants.Menu.SectionDescriptionFromIndex(i),
                    MenuItems = items ?? getItemMenus()

                }).ToList();

        }

        public static List<MenuItemCommand> getItemMenus(int count = 5)
        {
            return Enumerable.Range(0, count)
                .Select(i => new MenuItemCommand()
                {
                    Name = Constants.Menu.ItemName,
                    Description = Constants.Menu.ItemDescriptionFromIndex(i)
                }).ToList();
        }
       
    }
}
