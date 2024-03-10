using Photocenter.Models.Entities;

namespace Photocenter.Models.ViewModels
{
    public class OrderViewModel
    {
        public int ClientId { get; set; } 
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
