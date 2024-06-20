using Altiora.Dtos;
using Altiora.Helpers;
using Altiora.Models;
using Altiora.Repositories;

namespace Altiora.Services
{
    public class OrderService(IOrderRepository orderRepository, GeneralResponseDto generalResponse) : IOrderService
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private GeneralResponseDto _generalResponse = generalResponse;

        public async Task<GeneralResponseDto> GetAll()
        {
            _generalResponse = await _orderRepository.GetAll();

            return ResponseValidatorUtil.EvaluateListResponse<Order, OrderDto>(_generalResponse);
        }

        public async Task<GeneralResponseDto> FindByClientId(int clientId)
        {
            _generalResponse = await _orderRepository.GetByClientId(clientId);

            return ResponseValidatorUtil.EvaluateListResponse<Order, OrderDto>(_generalResponse);
        }
    }
}
