using Altiora.Contexts;
using Altiora.Dtos;
using Altiora.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Altiora.Repositories
{
    public class ClientRepository(AltioraContext context, GeneralResponseDto GeneralResponseDto, ILogger<ClientRepository> logger) : IClientRepository
    {
        private GeneralResponseDto _GeneralResponseDto = GeneralResponseDto;
        private AltioraContext _context = context;
        private readonly ILogger<ClientRepository> _logger = logger;

        public async Task<GeneralResponseDto> GetAll()
        {
            try
            {
                List<Client> lists = await _context.Clients
                                        .Include(x => x.Orders)
                                        .Where(e => !e.IsDeleted)
                                        .AsNoTracking()
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
                Client? client = await _context.Clients
                                        .Include(x => x.Orders)
                                        .FirstOrDefaultAsync(c => c.Id == id);

                if (client != null)
                {
                    _context.Entry(client).State = EntityState.Detached;
                    _GeneralResponseDto.state = true;
                }
                else
                {
                    client = new();
                    _GeneralResponseDto.state = false;
                }

                _GeneralResponseDto.entity = client;
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

        public async Task<GeneralResponseDto> Save(Client client)
        {
            try
            {
                _context.Clients.Attach(client);

                await _context.SaveChangesAsync()
                    .ConfigureAwait(false);

                _GeneralResponseDto.entity = client;
                _GeneralResponseDto.state = true;
            }
            catch (Exception ex)
            {
                _GeneralResponseDto.state = false;
                _GeneralResponseDto.message = ex.Message;
                _GeneralResponseDto.exception = ex.InnerException == null ? "" : ex.InnerException.ToString();

                _logger.LogError(ex, @"SaveOrUpdate({0})", JsonConvert.SerializeObject(client));
            }
            return _GeneralResponseDto;
        }

        public async Task<GeneralResponseDto> Update(Client client)
        {
            try
            {
                _context.Clients.Update(client);

                await _context.SaveChangesAsync()
                    .ConfigureAwait(false);

                _GeneralResponseDto.entity = client;
                _GeneralResponseDto.state = true;
            }
            catch (Exception ex)
            {
                _GeneralResponseDto.state = false;
                _GeneralResponseDto.message = ex.Message;
                _GeneralResponseDto.exception = ex.InnerException == null ? "" : ex.InnerException.ToString();

                _logger.LogError(ex, @"SaveOrUpdate({0})", JsonConvert.SerializeObject(client));
            }
            return _GeneralResponseDto;
        }
    }
}
