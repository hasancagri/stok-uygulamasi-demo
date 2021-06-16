using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Features.Commands.OrderCommands.CreateOrder;
using OrderService.Application.Features.Queries.OrderQueries.GetAllOrders;
using OrderService.Domain.Entities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController
        : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public OrdersController(IMediator mediator, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _mediator = mediator;
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }

        [HttpPost("createorder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            int orderId = await _mediator.Send(command);
            var orderCreatedEvent = _mapper.Map<OrderCreatedEvent>(command);
            orderCreatedEvent.OrderId = orderId;

            await _publishEndpoint.Publish(orderCreatedEvent);
            return Ok();
        }

        [HttpGet("getlist")]
        [ProducesResponseType(typeof(List<Order>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Order>>> Get()
        {
            var result = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(result);
        }
    }
}
