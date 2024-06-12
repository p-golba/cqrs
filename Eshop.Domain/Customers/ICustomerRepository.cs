namespace Eshop.Domain.Customers;

public interface ICustomerRepository
{
    void Add(Customer customer);

    Task<Customer> GetByIdAsync(Guid id);
}