using AutoMapper;
using OrderService.Application.Features.Commands.OrderCommands.CreateOrder;
using OrderService.Domain.Entities;

namespace OrderService.Application.Mappings
{
    public class MappingProfile
        : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrderCommand, Order>()
                .ReverseMap();
        }
    }
}
