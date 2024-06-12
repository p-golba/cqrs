using Eshop.Application.Configuration.Commands;
using Eshop.Application.Shared;

namespace Eshop.Application.CheckoutCard.Commands;

public class AddProductToCardCommand : CommandBase<Guid>
{
    public Guid CustomerId { get; }
    public ProductDto Product { get; }

    public AddProductToCardCommand(Guid customerId, ProductDto product)
    {
        CustomerId = customerId;
        Product = product ?? throw new ArgumentNullException(nameof(product));
    }
}