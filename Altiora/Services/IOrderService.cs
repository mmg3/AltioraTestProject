using Altiora.Dtos;

namespace Altiora.Services
{
    public interface IOrderService
    {
        Task<GeneralResponseDto> FindByClientId(int clientId);
        Task<GeneralResponseDto> GetAll();
    }
}