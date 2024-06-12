namespace Eshop.API.Controllers;

public class CreateCustomerRequest
{
    public string Name { get; set; }

    public CreateCustomerRequest(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}