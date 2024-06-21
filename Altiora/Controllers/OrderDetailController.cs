using Altiora.Extensions;
using Altiora.Services;
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
        public async Task<IActionResult> FindById(int orderId)
        {
            return Content((await _orderDetailService.FindByOrderId(orderId)).ToJson());
        }
    }
}
