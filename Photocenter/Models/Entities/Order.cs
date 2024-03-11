using Photocenter.Models.Enums;

namespace Photocenter.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; } 
        public Service Service { get; set; }
        public int ServiceId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Created;
    }
}
