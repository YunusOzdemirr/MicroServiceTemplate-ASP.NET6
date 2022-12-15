using System;
using MediatR;
using MicroServiceTemplate.Domain.Common;
using MicroServiceTemplate.Persistence.Context;

namespace MicroServiceTemplate.Persistence.Extensions
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, MicroServiceContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                                    .Entries<BaseEntity>()
                                    .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}

