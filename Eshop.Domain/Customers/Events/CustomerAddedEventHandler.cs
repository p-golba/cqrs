using MediatR;

namespace Eshop.Domain.Customers.Events;

public class CustomerAddedEventHandler : INotificationHandler<CustomerAddedEvent>
{
    public Task Handle(CustomerAddedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}