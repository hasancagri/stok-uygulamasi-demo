using MediatR;

namespace OrderService.Application.Features.Commands.OrderCommands.ReserveOrder
{
    public class ReserveOrderCommand
         : IRequest
    {
        public int OrderId { get; set; }
    }
}
