using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Customers.Rules;

public class CustomerNameMustOnlyContainLetters : IBusinessRule
{
    private readonly string _name;

    public CustomerNameMustOnlyContainLetters(string name)
    {
        _name = name;
    }

    public bool IsBroken() => !_name.All(char.IsLetter);

    public string Message => "Customer name must include only letters";
}