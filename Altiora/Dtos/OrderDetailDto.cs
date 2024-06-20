using System;
using System.Collections.Generic;

namespace Altiora.Dtos;

public partial class OrderDetailDto
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ArticleId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ArticleDto Article { get; set; } = null!;
}
