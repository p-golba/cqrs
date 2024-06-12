using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Customers.Events;

public class CustomerAddedEvent : DomainEventBase
{
    public Guid Id { get; }

    public CustomerAddedEvent(Guid id)
    {
        Id = id;
    }
}