using System;
using System.Collections.Generic;

namespace Altiora.Models;

public partial class Article
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
