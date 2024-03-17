using Photocenter.Models.Entities;
using Photocenter.Models.Enums;

namespace Photocenter.Models.ViewModels
{
    public class OrderViewModel
    {
        public int ClientId { get; set; } 
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
    }
}
