namespace EventBus.Messages.Events
{
    public class OrderDeletedEvent
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
