using Eshop.Domain.Orders.Events;
using MediatR;

public class OrderAddedEventHandler : INotificationHandler<OrderAddedEvent>
{
    public Task Handle(OrderAddedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
