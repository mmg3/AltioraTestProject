using System;
using System.Collections.Generic;

namespace Altiora.Dtos;

public partial class OrderDto
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Code { get; set; } = null!;

    public int ClientId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual List<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();

    public virtual ClientDto Client { get; set; } = null!;
}
