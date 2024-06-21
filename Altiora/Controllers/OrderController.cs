using Altiora.Extensions;
using Altiora.Services;
using Microsoft.AspNetCore.Mvc;

namespace Altiora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        [HttpGet("{clientId}")]
        public async Task<IActionResult> FindById(int clientId)
        {
            return Content((await _orderService.FindByClientId(clientId)).ToJson());
        }
    }
}
