using Eshop.Application.Configuration.Commands;
using Eshop.Application.Shared;

namespace Eshop.Application.Orders.CustomerOrder.Commands
{
    public class AddOrderCommand : CommandBase<Guid>
    {
        public Guid CustomerId { get; }

        public AddOrderCommand(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}