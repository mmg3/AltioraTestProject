using Altiora.Dtos;

namespace Altiora.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<GeneralResponseDto> GetAll();
        Task<GeneralResponseDto> GetById(int id);
        Task<GeneralResponseDto> Save(T entity);
        Task<GeneralResponseDto> Update(T entity);
    }
}
