using Eshop.Domain.Orders;
using Eshop.Domain.Products;
using Eshop.Domain.SeedWork;

namespace Eshop.Domain.CheckoutCart;

public class CheckoutCart : Entity, IAggregateRoot
{
    public Guid Id { get; private set; }
    
    public Guid CustomerId { get; private set; }
    
    public List<OrderProduct> Products { get; private set; }

    private CheckoutCart(Guid customerId)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        Products = new List<OrderProduct>();
    }

    public static CheckoutCart Create(Guid customerId)
    {
        return new CheckoutCart(customerId);
    }

    public void AddProductToCart(OrderProductData product, List<ProductPriceData> allProductPricesData)
    {
        var productPriceData = allProductPricesData.First(x => x.ProductId == product.ProductId);
        
        var orderProduct = OrderProduct.Create(product.ProductId, product.Quantity, productPriceData.UnitPrice);
        
        Products.Add(orderProduct);
    }
    
}