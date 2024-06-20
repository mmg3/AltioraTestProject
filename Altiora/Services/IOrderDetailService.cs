using Altiora.Dtos;

namespace Altiora.Services
{
    public interface IOrderDetailService
    {
        Task<GeneralResponseDto> FindByOrderId(int orderId);
    }
}