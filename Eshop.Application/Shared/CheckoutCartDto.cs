using Eshop.Domain.Orders;

namespace Eshop.Application.Shared;

public class CheckoutCartDto
{
    public Guid Id { get; private set; }
    
    public Guid CustomerId { get; private set; }
    
    public List<ProductDto> Products { get; private set; }
    
    private CheckoutCartDto() {}

    public CheckoutCartDto(Guid id, Guid customerId, List<ProductDto> products)
    {
        Id = id;
        CustomerId = customerId;
        Products = products;
    }
}