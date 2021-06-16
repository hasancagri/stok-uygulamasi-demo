using StockService.Domain.Common;

namespace StockService.Domain.Entities
{
    public class Stock
        : EntityBase
    {
        public int ProductId { get; set; }
        public int StockCount { get; set; }
    }
}
