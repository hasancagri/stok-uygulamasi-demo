using AutoMapper;
using MediatR;
using StockService.Application.Contracts.Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace StockService.Application.Features.Commands.StockCommands.ChangeStockQuantity
{
    public class ChangeStockQuantityCommandHandler
         : IRequestHandler<ChangeStockQuantityCommand>
    {

        private readonly IStockDal _stockDal;
        private readonly IMapper _mapper;

        public ChangeStockQuantityCommandHandler(IStockDal stockDal, IMapper mapper)
        {
            _stockDal = stockDal;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ChangeStockQuantityCommand request, CancellationToken cancellationToken)
        {
            await _stockDal.Update(request.Stock);
            return Unit.Value;
        }
    }
}
