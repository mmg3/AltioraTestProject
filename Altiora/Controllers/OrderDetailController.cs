using Altiora.Extensions;
using Altiora.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Altiora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class OrderDetailController(IOrderDetailService orderDetailService) : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService = orderDetailService;

        [HttpGet("{orderId}")]
        public async Task<string> FindById(int orderId)
        {
            return (await _orderDetailService.FindByOrderId(orderId)).ToJson();
        }
    }
}
