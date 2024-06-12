using Eshop.Application.Orders.CustomerOrder.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Eshop.Application.Customers.Commands;
using Eshop.Application.Customers.Queries;
using Eshop.Application.Shared;

namespace Eshop.API.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Adds a new order for a specified customer.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="request">List of products.</param>
        [Route("{customerId}/orders")]
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddCustomerOrder([FromRoute] Guid customerId)
        {
            var response = await _mediator.Send(new AddOrderCommand(customerId));
            return Created(string.Empty, response);
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddCustomer([FromBody] CreateCustomerRequest request)
        {
            var response = await _mediator.Send(new CreateCustomerCommand(request.Name));
            return Created(string.Empty, response);
        }

        [Route("{customerId}")]
        [HttpGet]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid customerId)
        {
            var response = await _mediator.Send(new GetCustomerQuery(customerId));
            return Ok(response);
        }
    }
}