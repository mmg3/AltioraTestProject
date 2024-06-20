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
        public async Task<string> GetAll()
        {
            return (await _clientService.GetAll()).ToJson();
        }

        [HttpGet("{clientId}")]
        public async Task<string> FindById(int clientId)
        {
            return (await _clientService.Find(clientId)).ToJson();
        }

        [HttpDelete("{clientId}")]
        public async Task<string> Delete(int clientId)
        {
            return (await _clientService.Delete(clientId)).ToJson();
        }

        [HttpPost()]
        public async Task<string> Create([FromBody] ClientDto clientDto)
        {
            return (await _clientService.SaveOrUpdate(clientDto)).ToJson();
        }

        [HttpPut()]
        public async Task<string> Update([FromBody] ClientDto clientDto)
        {
            return (await _clientService.SaveOrUpdate(clientDto)).ToJson();
        }
    }
}
