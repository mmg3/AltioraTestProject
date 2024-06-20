using Altiora.Extensions;
using Altiora.Dtos;
using Altiora.Services;
using Microsoft.AspNetCore.Mvc;

namespace Altiora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ClientController(IClientService clientService) : ControllerBase
    {
        private readonly IClientService _clientService = clientService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Content((await _clientService.GetAll()).ToJson());
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> FindById(int clientId)
        {
            return Content((await _clientService.Find(clientId)).ToJson());
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> Delete(int clientId)
        {
            return Content((await _clientService.Delete(clientId)).ToJson());
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] ClientDto clientDto)
        {
            return Content((await _clientService.SaveOrUpdate(clientDto)).ToJson());
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] ClientDto clientDto)
        {
            return Content((await _clientService.SaveOrUpdate(clientDto)).ToJson());
        }
    }
}
