using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Customers.Rules;

public class CustomerNameMustNotBeEmpty : IBusinessRule
{
    private readonly string _name;

    public CustomerNameMustNotBeEmpty(string name)
    {
        _name = name;
    }

    public bool IsBroken() => !_name.Any();

    public string Message => "Customer name can't be empty";
}