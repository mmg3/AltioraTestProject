using Altiora.Dtos;

namespace Altiora.Repositories
{
    public interface IOrderRepository
    {
        Task<GeneralResponseDto> Find(int id);
        Task<GeneralResponseDto> GetAll();
        Task<GeneralResponseDto> GetByClientId(int clientId);
    }
}