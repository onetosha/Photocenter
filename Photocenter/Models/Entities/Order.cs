namespace Photocenter.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; } 
        public Service Service { get; set; }
        public int ServiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
