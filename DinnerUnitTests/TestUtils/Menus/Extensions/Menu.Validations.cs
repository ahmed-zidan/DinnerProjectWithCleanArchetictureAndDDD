using Dinner.Application.Menus.Commands.CreateMenu;
using Dinner.Domain.MenuAggregate;
using Dinner.Domain.MenuAggregate.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerUnitTests.TestUtils.Menus.Extensions
{
    public static class MenuTest
    {
        public static void ValidateCreatedFrom(this Menu menu , CreateMenuCommand createdMenuCommand)
        {
            menu.Name.Should().Be(createdMenuCommand.Name);
            menu.Description.Should().Be(createdMenuCommand.Description);
            menu.MenuSections.Should().HaveSameCount(createdMenuCommand.MenuSections);
            menu.MenuSections.Zip(createdMenuCommand.MenuSections).ToList().ForEach(pair=>ValidateSections(pair.First , pair.Second));
        }

        private static void ValidateSections(MenuSection section, MenuSectionCommand command)
        {
            section.Id.Should().NotBeNull();
            section.Name.Should().Be(command.Name);
            section.Description.Should().Be(command.Description);
            section.Items.Should().HaveSameCount(command.MenuItems);
            section.Items.Zip(command.MenuItems).ToList().ForEach(pair => validateItems(pair.First, pair.Second));
        }

        private static void validateItems(MenuItem item, MenuItemCommand commandItem)
        {
            item.Id.Should().NotBeNull();
            item.Name.Should().Be(commandItem.Name);
            item.Description.Should().Be(commandItem.Description);
            

        }
    }
}
