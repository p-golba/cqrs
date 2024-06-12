using System.Net;
using Eshop.Application.CheckoutCard.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.API.Controllers;

[Route("api/v1/checkoutCarts")]
public class CheckoutCartController : Controller
{
    private readonly IMediator _mediator;

    public CheckoutCartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("")]
    [HttpPost]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> AddProductToCart([FromBody] ProductToCartRequest request)
    {
        var response = await _mediator.Send(new AddProductToCardCommand(request.CustomerId, request.Product));
        return Created(string.Empty, response);
    }
}