using Eshop.Domain.Customers.Rules;
using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Customers
{
    public class Customer : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; } 

        public string Name { get; private set; }    
        
        public static Customer Create(Guid id, string name)
        {
            CheckRule(new CustomerNameMustNotBeEmpty(name));
            CheckRule(new CustomerNameMustOnlyContainLetters(name));
            return new(id, name);
        }

        private Customer(Guid id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
