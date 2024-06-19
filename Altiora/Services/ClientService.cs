using Altiora.Dtos;
using Altiora.Helpers;
using Altiora.Models;
using Altiora.Repositories;

namespace Altiora.Services
{
    public class ClientService(IGenericRepository<Client> genericRepository, GeneralResponseDto generalResponse) : IClientService
    {
        private readonly IGenericRepository<Client> _genericRepository = genericRepository;
        private GeneralResponseDto _generalResponse = generalResponse;

        public async Task<GeneralResponseDto> SaveOrUpdate(ClientDto clientDto)
        {
            _generalResponse = new();

            Client client = MapperHelper.Map<ClientDto, Client>(clientDto);

            if (client.Id > 0)
            {
                _generalResponse = await _genericRepository.Update(client);
            }
            else
            {
                _generalResponse = await _genericRepository.Save(client);
            }

            if (_generalResponse.state)
            {
                client = _generalResponse.entity;
                clientDto = MapperHelper.Map<Client, ClientDto>(client);
                _generalResponse.entity = clientDto;
            }
            else
            {
                _generalResponse.entity = new ClientDto();
            }
            return _generalResponse;
        }

        public async Task<GeneralResponseDto> Delete(int clientId)
        {
            var responseClient = await Find(clientId);
            ClientDto clientDto = responseClient.entity;

            if (clientDto != null && !clientDto.IsDeleted)
            {
                clientDto.IsDeleted = true;
                Client client = MapperHelper.Map<ClientDto, Client>(clientDto);
                _generalResponse = await _genericRepository.Update(client);


                if (_generalResponse.state)
                {
                    client = _generalResponse.entity;
                    clientDto = MapperHelper.Map<Client, ClientDto>(client);
                    _generalResponse.entity = clientDto;
                }
                else
                {
                    _generalResponse.entity = new ClientDto();
                    _generalResponse.state = false;
                    _generalResponse.message = "Wrong parameters";
                }
            }
            return _generalResponse;
        }

        public async Task<GeneralResponseDto> Find(int clientId)
        {
            _generalResponse = await _genericRepository.GetById(clientId);

            if (_generalResponse.state)
            {
                Client client = _generalResponse.entity;
                ClientDto clientDto = MapperHelper.Map<Client, ClientDto>(client);
                _generalResponse.entity = clientDto;
            }
            else
            {
                _generalResponse.entity = new ClientDto();
                _generalResponse.message = "Wrong parameters";
            }
            return _generalResponse;
        }

        public async Task<GeneralResponseDto> GetAll()
        {
            _generalResponse = await _genericRepository.GetAll();

            if (_generalResponse.state)
            {
                List<Client> clients = _generalResponse.entity;
                List<ClientDto> clientsDto = MapperHelper.MapList<Client, ClientDto>(clients);
                _generalResponse.entity = clientsDto;
            }
            else
            {
                _generalResponse.entity = new ClientDto();
                _generalResponse.message = "Wrong parameters";
            }

            return _generalResponse;
        }
    }
}
