using Altiora.Dtos;

namespace Altiora.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<GeneralResponseDto> GetByOrderId(int orderId);
    }
}