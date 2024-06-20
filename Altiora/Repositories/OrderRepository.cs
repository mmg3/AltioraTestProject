using Altiora.Contexts;
using Altiora.Dtos;
using Altiora.Models;
using Microsoft.EntityFrameworkCore;

namespace Altiora.Repositories
{
    public class OrderRepository(AltioraContext context, GeneralResponseDto GeneralResponseDto, ILogger<OrderRepository> logger) : IOrderRepository
    {
        private GeneralResponseDto _GeneralResponseDto = GeneralResponseDto;
        private AltioraContext _context = context;
        private readonly ILogger<OrderRepository> _logger = logger;

        public async Task<GeneralResponseDto> GetAll()
        {
            try
            {
                List<Order> lists = await _context.Orders
                                        .Include(x => x.OrderDetails)
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

        public async Task<GeneralResponseDto> GetByClientId(int clientId)
        {
            try
            {
                List<Order> lists = await _context.Orders
                                        .Include(y => y.Client)
                                        .Where(o => o.ClientId == clientId)
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

        public async Task<GeneralResponseDto> Find(int id)
        {
            try
            {
                List<Order> lists = await _context.Orders
                                        .Include(x => x.OrderDetails)
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
    }
}
