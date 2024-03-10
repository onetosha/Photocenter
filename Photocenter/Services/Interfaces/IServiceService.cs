using Photocenter.Models.Entities;
using Photocenter.Models.Response;
using Photocenter.Models.ViewModels;

namespace Photocenter.Services.Interfaces
{
    public interface IServiceService
    {
        Task<IBaseResponse<IEnumerable<Service>>> GetServices();
        Task<IBaseResponse<Service>> GetService(int id);
        Task<IBaseResponse<Service>> CreateService(ServiceViewModel model);
        Task<IBaseResponse<bool>> DeleteService(int id);
        Task<IBaseResponse<Service>> EditService(int id, ServiceViewModel model);
    }
}
