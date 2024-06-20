using Altiora.Dtos;
using Altiora.Helpers;
using Altiora.Models;
using Altiora.Repositories;

namespace Altiora.Services
{
    public class OrderDetailService(IOrderDetailRepository orderDetailRepository, GeneralResponseDto generalResponse) : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository = orderDetailRepository;
        private GeneralResponseDto _generalResponse = generalResponse;

        public async Task<GeneralResponseDto> FindByOrderId(int orderId)
        {
            _generalResponse = await _orderDetailRepository.GetByOrderId(orderId);

            return ResponseValidatorUtil.EvaluateListResponse<OrderDetail, OrderDetailDto>(_generalResponse);
        }
    }
}
