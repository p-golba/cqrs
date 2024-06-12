using Eshop.Domain.CheckoutCart;
using MongoDB.Driver;

namespace Eshop.Infrastructure.Database;

internal class CheckoutCartContext
{
    private readonly IMongoDatabase _database;

    public CheckoutCartContext(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<CheckoutCart> CheckoutCarts => _database.GetCollection<CheckoutCart>(nameof(CheckoutCart));
}