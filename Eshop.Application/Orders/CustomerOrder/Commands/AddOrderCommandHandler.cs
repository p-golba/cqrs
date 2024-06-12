using Eshop.Application.Configuration.Commands;
using Eshop.Domain.CheckoutCart;
using Eshop.Domain.Orders;
using Eshop.Domain.SeedWork;

namespace Eshop.Application.Orders.CustomerOrder.Commands
{
    public class AddOrderCommandHandler : ICommandHandler<AddOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICheckoutCartRepository _checkoutCartRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddOrderCommandHandler(
            IOrderRepository orderRepository,
            ICheckoutCartRepository checkoutCartRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _checkoutCartRepository =
                checkoutCartRepository ?? throw new ArgumentNullException(nameof(checkoutCartRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Guid> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            
            var response = await _checkoutCartRepository.GetByCustomerIdAsync(request.CustomerId);

            var checkoutCart = response ?? CheckoutCart.Create(request.CustomerId);

            var order = Order.Create(checkoutCart);

            _orderRepository.Add(order);

            await _unitOfWork.CommitAsync(cancellationToken);

            return order.Id;
        }
    }
}