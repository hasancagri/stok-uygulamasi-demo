using OrderService.Domain.Common;
using OrderService.Domain.Enums;

namespace OrderService.Domain.Entities
{
    public class Order
        : EntityBase
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
