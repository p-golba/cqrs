using Eshop.Application.Shared;
using Eshop.Domain.Orders;

namespace Eshop.API.Controllers;

public class ProductToCartRequest
{
    public Guid CustomerId { get; set; }

    public ProductDto Product { get; set; }

    public ProductToCartRequest(Guid customerId, ProductDto product)
    {
        CustomerId = customerId;
        Product = product ?? throw new ArgumentNullException(nameof(product));
    }
}