using Eshop.Domain.CheckoutCart;
using Eshop.Infrastructure.Database;
using MongoDB.Driver;

namespace Eshop.Infrastructure.Repositories;

internal class CheckoutCartRepository : ICheckoutCartRepository
{
    private readonly CheckoutCartContext _context;
    private readonly IEntityTracker _entityTracker;

    public CheckoutCartRepository(CheckoutCartContext context, IEntityTracker entityTracker)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _entityTracker = entityTracker ?? throw new ArgumentNullException(nameof(entityTracker));
    }

    public void Add(CheckoutCart checkoutCart)
    {
        _entityTracker.TrackEntity(checkoutCart);
    }

    public async Task<CheckoutCart?> GetByCustomerIdAsync(Guid customerId)
    {
        var checkoutCart = await _context.CheckoutCarts.Find(c => c.CustomerId == customerId).FirstOrDefaultAsync();
        if (checkoutCart == null)
        {
            return null;
        }
        
        _entityTracker.TrackEntity(checkoutCart);

        return checkoutCart;
    }
}