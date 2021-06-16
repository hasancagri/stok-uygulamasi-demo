using AutoMapper;
using MediatR;
using OrderService.Application.Contracts.Persistance;
using OrderService.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Commands.OrderCommands.CreateOrder
{
    public class CreateOrderCommandHandler
        : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderDal _orderDal;
        private readonly IMapper _mapper;
        public CreateOrderCommandHandler(IOrderDal orderDal, IMapper mapper)
        {
            _orderDal = orderDal;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            int orderId = await _orderDal.Add(order);
            return orderId;
        }
    }
}
