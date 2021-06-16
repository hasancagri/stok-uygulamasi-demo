using MediatR;

namespace OrderService.Application.Features.Commands.OrderCommands.ReleaseOrder
{
    public class ReleaseOrderCommand
        : IRequest
    {
        public int Id { get; set; }
    }
}
