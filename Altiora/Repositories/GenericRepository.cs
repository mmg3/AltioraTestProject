using Altiora.Contexts;
using Altiora.Dtos;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Altiora.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private GeneralResponseDto _GeneralResponseDto;
        private AltioraContext _context;
        private readonly ILogger<T> _logger;
        private readonly DbSet<T> _table;

        public GenericRepository(AltioraContext context, GeneralResponseDto GeneralResponseDto, ILogger<T> logger)
        {
            _GeneralResponseDto = GeneralResponseDto;
            _context = context;
            _logger = logger;

            _table = _context.Set<T>();
        }

        public async Task<GeneralResponseDto> GetAll()
        {
            try
            {
                List<T> lists = await _table.AsNoTracking()
                                        .ToListAsync()
                                        .ConfigureAwait(false);

                if (lists.Count > 0)
                {
                    _GeneralResponseDto.state = true;
                }
                else
                {
                    _GeneralResponseDto.state = false;
                }

                _GeneralResponseDto.entity = lists;
            }
            catch (Exception ex)
            {
                _GeneralResponseDto.state = false;
                _GeneralResponseDto.message = ex.Message;
                _GeneralResponseDto.exception = ex.InnerException == null ? "" : ex.InnerException.ToString();

                _logger.LogError(ex, @"GetAll()");
            }
            return _GeneralResponseDto;
        }

        public async Task<GeneralResponseDto> GetById(int id)
        {
            try
            {
                T? entity = await _table
                                        .FindAsync(id)
                                        .ConfigureAwait(false);

                if (entity != null)
                {
                    _context.Entry(entity).State = EntityState.Detached;
                    _GeneralResponseDto.state = true;
                }
                else
                {
                    _GeneralResponseDto.state = false;
                }

                _GeneralResponseDto.entity = entity != null ? entity : "Wrong parameters";
            }
            catch (Exception ex)
            {
                _GeneralResponseDto.state = false;
                _GeneralResponseDto.message = ex.Message;
                _GeneralResponseDto.exception = ex.InnerException == null ? "" : ex.InnerException.ToString();

                _logger.LogError(ex, @"GetById(int {0})", id);
            }
            return _GeneralResponseDto;
        }

        public async Task<GeneralResponseDto> Save(T entity)
        {
            try
            {
                _table.Attach(entity);

                await _context.SaveChangesAsync()
                    .ConfigureAwait(false);

                _GeneralResponseDto.entity = entity;
                _GeneralResponseDto.state = true;
            }
            catch (Exception ex)
            {
                _GeneralResponseDto.state = false;
                _GeneralResponseDto.message = ex.Message;
                _GeneralResponseDto.exception = ex.InnerException == null ? "" : ex.InnerException.ToString();

                _logger.LogError(ex, @"SaveOrUpdate({0})", JsonConvert.SerializeObject(entity));
            }
            return _GeneralResponseDto;
        }

        public async Task<GeneralResponseDto> Update(T entity)
        {
            try
            {
                _table.Update(entity);

                await _context.SaveChangesAsync()
                    .ConfigureAwait(false);

                _GeneralResponseDto.entity = entity;
                _GeneralResponseDto.state = true;
            }
            catch (Exception ex)
            {
                _GeneralResponseDto.state = false;
                _GeneralResponseDto.message = ex.Message;
                _GeneralResponseDto.exception = ex.InnerException == null ? "" : ex.InnerException.ToString();

                _logger.LogError(ex, @"SaveOrUpdate({0})", JsonConvert.SerializeObject(entity));
            }
            return _GeneralResponseDto;
        }
    }
}
