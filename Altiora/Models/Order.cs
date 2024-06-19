using System;
using System.Collections.Generic;

namespace Altiora.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Code { get; set; } = null!;

    public int ClientId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
