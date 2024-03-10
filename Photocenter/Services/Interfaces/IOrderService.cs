using Photocenter.Models.Entities;
using Photocenter.Models.Response;
using Photocenter.Models.ViewModels;

namespace Photocenter.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IBaseResponse<IEnumerable<Order>>> GetOrders();
        Task<IBaseResponse<Order>> GetOrder(int id);
        Task<IBaseResponse<Order>> CreateOrder(OrderViewModel model);
        Task<IBaseResponse<bool>> DeleteOrder(int id);
        Task<IBaseResponse<Order>> EditOrder(int id, OrderViewModel model);
    }
}
