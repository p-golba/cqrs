using AutoMapper;
using Eshop.Application.Configuration.Commands;
using Eshop.Domain.CheckoutCart;
using Eshop.Domain.Orders;
using Eshop.Domain.SeedWork;

namespace Eshop.Application.CheckoutCard.Commands;

public class AddProductToCardCommandHandler : ICommandHandler<AddProductToCardCommand, Guid>
{
    private readonly ICheckoutCartRepository _checkoutCartRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductPriceDataApi _productPriceDataApi;

    public AddProductToCardCommandHandler(ICheckoutCartRepository checkoutCardRepository, IMapper mapper,
        IUnitOfWork unitOfWork, IProductPriceDataApi productPriceDataApi)
    {
        _checkoutCartRepository = checkoutCardRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _productPriceDataApi = productPriceDataApi;
    }

    public async Task<Guid> Handle(AddProductToCardCommand request, CancellationToken cancellationToken)
    {
        var productsData = await _productPriceDataApi.Get();

        var response = await _checkoutCartRepository.GetByCustomerIdAsync(request.CustomerId);

        var checkoutCart = response ?? CheckoutCart.Create(request.CustomerId);
        
        checkoutCart.AddProductToCart(_mapper.Map<OrderProductData>(request.Product), productsData);
        
        _checkoutCartRepository.Add(checkoutCart);

        await _unitOfWork.CommitAsync(cancellationToken);

        return checkoutCart.Id;
    }
}