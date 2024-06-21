using Altiora.Contexts;
using Altiora.Dtos;
using Altiora.Models;
using Microsoft.EntityFrameworkCore;

namespace Altiora.Repositories
{
    public class OrderDetailRepository(AltioraContext context, GeneralResponseDto GeneralResponseDto, ILogger<OrderDetailRepository> logger) : IOrderDetailRepository
    {
        private GeneralResponseDto _GeneralResponseDto = GeneralResponseDto;
        private AltioraContext _context = context;
        private readonly ILogger<OrderDetailRepository> _logger = logger;

        public async Task<GeneralResponseDto> GetByOrderId(int orderId)
        {
            try
            {
                List<OrderDetail> lists = await _context.OrderDetails
                                        .Include(a => a.Article)
                                        .Where(o => o.OrderId == orderId && !o.IsDeleted)
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
