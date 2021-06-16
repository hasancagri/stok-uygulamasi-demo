using AutoMapper;
using StockService.Application.Features.Commands.StockCommands.ChangeStockQuantity;
using StockService.Domain.Entities;

namespace StockService.Application.Mappings
{
    public class MappingProfile
         : Profile
    {
        public MappingProfile()
        {
            CreateMap<ChangeStockQuantityCommand, Stock>()
                .ReverseMap();
        }
    }
}
