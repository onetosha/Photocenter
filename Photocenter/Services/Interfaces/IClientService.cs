using Photocenter.Models.Entities;
using Photocenter.Models.Response;
using Photocenter.Models.ViewModels;

namespace Photocenter.Services.Interfaces
{
    public interface IClientService
    {
        Task<IBaseResponse<IEnumerable<Client>>> GetClients();
        Task<IBaseResponse<Client>> GetClient(int id);
        Task<IBaseResponse<Client>> CreateClient(ClientViewModel model);
        Task<IBaseResponse<bool>> DeleteClient(int id);
        Task<IBaseResponse<Client>> EditClient(int id, ClientViewModel model);
    }
}
