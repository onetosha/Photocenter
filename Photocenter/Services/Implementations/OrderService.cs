using Photocenter.DAL.Interfaces;
using Photocenter.DAL.Repositories;
using Photocenter.Models.Entities;
using Photocenter.Models.Enums;
using Photocenter.Models.Response;
using Photocenter.Models.ViewModels;
using Photocenter.Services.Interfaces;

namespace Photocenter.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IClientRepository _clientRepository;
        public OrderService(IOrderRepository orderRepository, IServiceRepository serviceRepository, IClientRepository clientRepository)
        {
            _orderRepository = orderRepository;
            _serviceRepository = serviceRepository;
            _clientRepository = clientRepository;
        }
        public async Task<IBaseResponse<Order>> CreateOrder(OrderViewModel model)
        {
            var baseResponse = new BaseResponse<Order>();
            try
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                var service = await _serviceRepository.Get(model.ServiceId);
                var order = new Order()
                {
                    ClientId = model.ClientId,
                    ServiceId = model.ServiceId,
                    Date = model.Date,
                    Amount = service.Price,
                    Status = model.Status
                };
                await _orderRepository.Create(order);
                baseResponse.Data = order;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = $"[CreateOrder] : {ex.Message}";
                baseResponse.StatusCode = StatusCode.InternalServiceError;
                return baseResponse;
            }
        }

        public async Task<IBaseResponse<bool>> DeleteOrder(int id)
        {
            var baseResponse = new BaseResponse<bool>() { Data = false };

            try
            {
                var order = await _orderRepository.Get(id);
                if (order == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                await _orderRepository.Delete(order);
                baseResponse.Data = true;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = $"[DeleteOrder] : {ex.Message}";
                baseResponse.StatusCode = StatusCode.InternalServiceError;
                return baseResponse;
            }
        }

        public async Task<IBaseResponse<Order>> EditOrder(int id, OrderViewModel model)
        {
            var baseResponse = new BaseResponse<Order>();
            try
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                var service = await _serviceRepository.Get(model.ServiceId);
                var order = await _orderRepository.Get(id);
                if (order == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                order.ServiceId = model.ServiceId;
                order.ClientId = model.ClientId;
                order.Status = model.Status;
                order.Date = model.Date;
                order.Amount = service.Price;
                await _orderRepository.Update(order);
                baseResponse.Data = order;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = $"[EditOrder] : {ex.Message}";
                baseResponse.StatusCode = StatusCode.InternalServiceError;
                return baseResponse;
            }
        }

        public async Task<IBaseResponse<Order>> GetOrder(int id)
        {
            var baseResponse = new BaseResponse<Order>();
            try
            {
                var order = await _orderRepository.Get(id);
                if (order == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                baseResponse.Data = order;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = $"[GetOrder] : {ex.Message}";
                baseResponse.StatusCode = StatusCode.InternalServiceError;
                return baseResponse;
            }
        }

        public async Task<IBaseResponse<IEnumerable<Order>>> GetOrders()
        {
            var baseResponse = new BaseResponse<IEnumerable<Order>>();
            try
            {
                var orderList = await _orderRepository.GetAll();
                if (orderList.Count == 0)
                {
                    baseResponse.Description = "0 objects found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                baseResponse.Data = orderList;
                return baseResponse;

            }
            catch (Exception ex)
            {
                baseResponse.Description = $"[GetOrders] : {ex.Message}";
                baseResponse.StatusCode = StatusCode.InternalServiceError;
                return baseResponse;
            }
        }
    }
}
