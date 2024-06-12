using Eshop.Domain.Orders;

namespace Eshop.Domain.CheckoutCart;

public interface ICheckoutCartRepository
{
    void Add(CheckoutCart checkoutCart);

    Task<CheckoutCart?> GetByCustomerIdAsync(Guid customerId);
}