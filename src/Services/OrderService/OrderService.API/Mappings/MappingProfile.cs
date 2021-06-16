using AutoMapper;
using EventBus.Messages.Events;
using OrderService.Application.Features.Commands.OrderCommands.CreateOrder;

namespace OrderService.API.Mappings
{
    public class MappingProfile
        : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderCreatedEvent, CreateOrderCommand>()
                .ReverseMap();
        }
    }
}
