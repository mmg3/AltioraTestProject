using Altiora.Dtos;
using Altiora.Models;

namespace Altiora.Repositories
{
    public interface IClientRepository
    {
        Task<GeneralResponseDto> GetAll();
        Task<GeneralResponseDto> GetById(int id);
        Task<GeneralResponseDto> Save(Client client);
        Task<GeneralResponseDto> Update(Client client);
    }
}