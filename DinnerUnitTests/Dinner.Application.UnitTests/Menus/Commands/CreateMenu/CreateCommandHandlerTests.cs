using Dinner.Application.Common.Interfaces.Repositories;
using Dinner.Application.Menus.Commands.CreateMenu;
using DinnerUnitTests.Dinner.Application.UnitTests.Menus.Commands.TestUtils;
using DinnerUnitTests.TestUtils.Menus.Extensions;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DinnerUnitTests.Dinner.Application.UnitTests.Menus.Commands.CreateMenu
{
    public class CreateCommandHandlerTests
    {
        private readonly CreateCommandHandler _createCommandHandler;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public CreateCommandHandlerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _createCommandHandler = new CreateCommandHandler(_mockUnitOfWork.Object);
        }

        [Theory]
        [MemberData(nameof(ValidCreateMenuCommands))]
        public async Task HandleCreateMenue_whenMenuCreated_shouldCreateAndReturnMenu(CreateMenuCommand CreateMenu)
        {
            //Arrange
            //act
            var res = await _createCommandHandler.Handle(CreateMenu,default);
            //assert
            res.AsT0.ValidateCreatedFrom(CreateMenu);
            _mockUnitOfWork.Verify(x=>x._menuRepo.CreateMenuAsync(res.AsT0),Times.Once);
        }

        public static IEnumerable<Object[]> ValidCreateMenuCommands()
        {
            yield return new Object[] { CreateMenuCommandUtils.CreateCommand };
            yield return new Object[] {
                CreateMenuCommandUtils.CreateCommand(
                   sections:CreateMenuCommandUtils.getMenuSections(3))
            };
            yield return new Object[] {
                CreateMenuCommandUtils.CreateCommand(
                   sections:CreateMenuCommandUtils.getMenuSections(3,
                   items:CreateMenuCommandUtils.getItemMenus(4)))
            };
            //yield return new Object[] { CreateMenuCommandUtils.CreateCommand };
        }
    
    }
}
