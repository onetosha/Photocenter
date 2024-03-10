using Photocenter.DAL.Interfaces;
using Photocenter.Models.Entities;
using Photocenter.Models.Enums;
using Photocenter.Models.Response;
using Photocenter.Models.ViewModels;
using Photocenter.Services.Interfaces;

namespace Photocenter.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<IBaseResponse<Client>> CreateClient(ClientViewModel model)
        {
            var baseResponse = new BaseResponse<Client>();

            try
            {
                var client = new Client()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone
                };

                await _clientRepository.Create(client);
                baseResponse.Data = client;
                return baseResponse;
            }
            catch(Exception ex) 
            {
                baseResponse.Description = $"[CreateClient] : {ex.Message}";
                baseResponse.StatusCode = StatusCode.InternalServiceError;
                return baseResponse;
            }
        }

        public async Task<IBaseResponse<bool>> DeleteClient(int id)
        {
            var baseResponse = new BaseResponse<bool>() { Data = false };
            
            try
            {
                var client = await _clientRepository.Get(id);
                if (client == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                await _clientRepository.Delete(client);
                baseResponse.Data = true;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = $"[DeleteClient] : {ex.Message}";
                baseResponse.StatusCode = StatusCode.InternalServiceError;
                return baseResponse;
            }
        }

        public async Task<IBaseResponse<Client>> EditClient(int id, ClientViewModel model)
        {
            var baseResponse = new BaseResponse<Client>();
            try
            {
                var client = await _clientRepository.Get(id);
                if (client == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                client.FirstName = model.FirstName;
                client.LastName = model.LastName;
                client.Email = model.Email;
                client.Phone = model.Phone;
                await _clientRepository.Update(client);
                baseResponse.Data = client;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = $"[EditClient] : {ex.Message}";
                baseResponse.StatusCode = StatusCode.InternalServiceError;
                return baseResponse;
            }
        }

        public async Task<IBaseResponse<Client>> GetClient(int id)
        {
            var baseResponse = new BaseResponse<Client>();
            try
            {
                var client = await _clientRepository.Get(id);
                if (client == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                baseResponse.Data = client;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = $"[GetClient] : {ex.Message}";
                baseResponse.StatusCode = StatusCode.InternalServiceError;
                return baseResponse;
            }
        }

        public async Task<IBaseResponse<IEnumerable<Client>>> GetClients()
        {
            var baseResponse = new BaseResponse<IEnumerable<Client>>();
            try
            {
                var clientList = await _clientRepository.GetAll();
                if (clientList.Count == 0)
                {
                    baseResponse.Description = "0 objects found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                baseResponse.Data = clientList;
                return baseResponse;
                
            }
            catch (Exception ex)
            {
                baseResponse.Description = $"[GetClients] : {ex.Message}";
                baseResponse.StatusCode = StatusCode.InternalServiceError;
                return baseResponse;
            }
        }
    }
}
