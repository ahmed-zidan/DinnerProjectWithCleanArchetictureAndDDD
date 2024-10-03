using Dinner.Domain.MenuAggregate.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Menus.Events
{
    public class DummyHandler : INotificationHandler<MenuCreated>
    {
        public async Task Handle(MenuCreated notification, CancellationToken cancellationToken)
        {
             await Task.CompletedTask;
        }
    }
}
