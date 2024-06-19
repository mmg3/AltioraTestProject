﻿using System;
using System.Collections.Generic;

namespace Altiora.Models;

public partial class OrderDetailDto
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ArticleId { get; set; }

    public int UnitPrice { get; set; }

    public int Quantity { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual OrderDto Order { get; set; } = null!;
}