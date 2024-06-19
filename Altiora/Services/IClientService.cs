using Altiora.Dtos;
using Altiora.Models;

namespace Altiora.Services
{
    public interface IClientService
    {
        Task<GeneralResponseDto> Delete(int clientId);
        Task<GeneralResponseDto> Find(int clientId);
        Task<GeneralResponseDto> GetAll();
        Task<GeneralResponseDto> SaveOrUpdate(ClientDto clientDto);
    }
}