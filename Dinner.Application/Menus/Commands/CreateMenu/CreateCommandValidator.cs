using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Menus.Commands.CreateMenu
{
    internal class CreateCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.MenuSections).NotEmpty();
        }
    }
}
