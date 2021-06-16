using MediatR;
using StockService.Domain.Entities;

namespace StockService.Application.Features.Commands.StockCommands.ChangeStockQuantity
{
    public class ChangeStockQuantityCommand
        : IRequest
    {
        public Stock Stock { get; set; }
    }
}
