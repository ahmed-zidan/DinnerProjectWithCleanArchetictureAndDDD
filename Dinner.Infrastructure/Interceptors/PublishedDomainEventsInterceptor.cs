using Dinner.Domain.Common.Models;
using Dinner.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace Dinner.Infrastructure.Interceptors
{
    public class PublishedDomainEventsInterceptor : SaveChangesInterceptor
    {
        private readonly IPublisher _mediator;

        public PublishedDomainEventsInterceptor(IPublisher mediator)
        {
            _mediator = mediator;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await PublishDomainEvents(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private async Task PublishDomainEvents(DbContext? context)
        {
            if (context is null)
            {
                return;
            }
            // get hold of the entities
            var entitiesWithDomainEvents = context.ChangeTracker.Entries<IHasDomainEvents>()
                .Where(entrry=> entrry.Entity.DomainEvents.Any()
                ).Select(entrry => entrry.Entity).ToList();
            //get hold of various domain events
            var domainEvents = entitiesWithDomainEvents.SelectMany(entity=> entity.DomainEvents).ToList();
            //clear domain events
            entitiesWithDomainEvents.ForEach(entity => entity.ClreaDomainEvents());
            //publish domain events
            foreach (var domainEvent in domainEvents) {
                await _mediator.Publish(domainEvent);
            } 

        }
    }
}
