using Altiora.Dtos;
using Altiora.Utils;
using Altiora.Models;
using Altiora.Repositories;
using Altiora.Helpers;

namespace Altiora.Services
{
    public class ClientService(IClientRepository clientRepository, GeneralResponseDto generalResponse) : IClientService
    {
        private readonly IClientRepository _clientRepository = clientRepository;
        private GeneralResponseDto _generalResponse = generalResponse;

        public async Task<GeneralResponseDto> SaveOrUpdate(ClientDto clientDto)
        {
            _generalResponse = new();

            Client client = MapperUtil.Map<ClientDto,Client>(clientDto);

            if (client.Id > 0)
            {
                _generalResponse = await _clientRepository.Update(client);
            }
            else
            {
                _generalResponse = await _clientRepository.Save(client);
            }

            return ResponseValidatorUtil.EvaluateResponse<Client, ClientDto>(_generalResponse);
        }

        public async Task<GeneralResponseDto> Delete(int clientId)
        {
            var responseClient = await Find(clientId);
            ClientDto clientDto = responseClient.entity;

            if (clientDto != null && !clientDto.IsDeleted)
            {
                clientDto.IsDeleted = true;
                Client client = MapperUtil.Map<ClientDto,Client>(clientDto);
                _generalResponse = await _clientRepository.Update(client);
            }

            return ResponseValidatorUtil.EvaluateResponse<Client, ClientDto>(_generalResponse);
        }

        public async Task<GeneralResponseDto> Find(int clientId)
        {
            _generalResponse = await _clientRepository.GetById(clientId);

            return ResponseValidatorUtil.EvaluateResponse<Client, ClientDto>(_generalResponse);
        }

        public async Task<GeneralResponseDto> GetAll()
        {
            _generalResponse = await _clientRepository.GetAll();

            return ResponseValidatorUtil.EvaluateListResponse<Client, ClientDto>(_generalResponse);
        }
    }
}
