using KOF.RouteMap.Domain.Common;

namespace KOF.RouteMap.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
