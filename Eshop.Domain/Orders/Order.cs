using Eshop.Domain.Orders.Events;
using Eshop.Domain.Orders.Rules;
using Eshop.Domain.CheckoutCart;
using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Orders
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }

        public Guid CustomerId { get; private set; }

        public List<OrderProduct> Products { get; private set; }

        private Order(Guid customerId, List<OrderProduct> orderProducts)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            Products = orderProducts ?? throw new ArgumentNullException(nameof(orderProducts));

            AddDomainEvent(new OrderAddedEvent(Id, customerId));
        }

        public static Order Create(CheckoutCart.CheckoutCart checkoutCart)
        {
            CheckRule(new OrderMustHaveAtLeastOneProductRule(checkoutCart.Products));
            CheckRule(new OrderTotalMustBeLowerThan15000(checkoutCart.Products));

            return new Order(checkoutCart.CustomerId, checkoutCart.Products);
        }
    }
}
