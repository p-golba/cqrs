using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Orders.Rules;

public class OrderTotalMustBeLowerThan15000 : IBusinessRule
{
    private readonly List<OrderProduct> _orderProducts;
    public OrderTotalMustBeLowerThan15000(List<OrderProduct> orderProducts)
    {
        _orderProducts = orderProducts;
    }

    public bool IsBroken() => _orderProducts.Sum(p => p.TotalCost) <= 15000;

    public string Message => "Order total must be lower than 15000";
}