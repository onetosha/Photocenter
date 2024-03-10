using Photocenter.DAL.Interfaces;
using Photocenter.DAL.Repositories;
using Photocenter.Models.Entities;
using Photocenter.Models.Enums;
using Photocenter.Models.Response;
using Photocenter.Models.ViewModels;
using Photocenter.Services.Interfaces;

namespace Photocenter.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IBaseResponse<Service>> CreateService(ServiceViewModel model)
        {
            var baseResponse = new BaseResponse<Service>();
            try
            {
                Service service = new Service()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price
                };
                await _serviceRepository.Create(service);
                baseResponse.Data = service;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = $"[CreateService] : {ex.Message}";
                baseResponse.StatusCode = Models.Enums.StatusCode.InternalServiceError;
                return baseResponse;
            }
        }

        public async Task<IBaseResponse<bool>> DeleteService(int id)
        {
            var baseResponse = new BaseResponse<bool>() { Data = false };

            try
            {
                var service = await _serviceRepository.Get(id);
                if (service == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                await _serviceRepository.Delete(service);
                baseResponse.Data = true;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = $"[DeleteService] : {ex.Message}";
                baseResponse.StatusCode = StatusCode.InternalServiceError;
                return baseResponse;
            }
        }

        public async Task<IBaseResponse<Service>> EditService(int id, ServiceViewModel model)
        {
            var baseResponse = new BaseResponse<Service>();
            try
            {
                var service = await _serviceRepository.Get(id);
                if (service == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                service.Price = model.Price;
                service.Description = model.Description;
                service.Name = model.Name;
                await _serviceRepository.Update(service);
                baseResponse.Data = service;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = $"[EditService] : {ex.Message}";
                baseResponse.StatusCode = StatusCode.InternalServiceError;
                return baseResponse;
            }
        }

        public async Task<IBaseResponse<IEnumerable<Service>>> GetServices()
        {
            var baseResponse = new BaseResponse<IEnumerable<Service>>();
            try
            {
                var serviceList = await _serviceRepository.GetAll();
                if (serviceList.Count == 0)
                {
                    baseResponse.Description = "0 objects found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                baseResponse.Data = serviceList;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = $"[GetServices] : {ex.Message}";
                baseResponse.StatusCode = StatusCode.InternalServiceError;
                return baseResponse;
            }
        }

        public async Task<IBaseResponse<Service>> GetService(int id)
        {
            var baseResponse = new BaseResponse<Service>();
            try
            {
                var service = await _serviceRepository.Get(id);
                if (service == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                baseResponse.Data = service;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = $"[GetService] : {ex.Message}";
                baseResponse.StatusCode = StatusCode.InternalServiceError;
                return baseResponse;
            }
        }
    }
}
