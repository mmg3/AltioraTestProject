using System;
using System.Collections.Generic;

namespace Altiora.Models;

public partial class Client
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Identification { get; set; } = null!;

    public string? Email { get; set; }

    public bool IsDeleted { get; set; }

    public virtual List<Order>? Orders { get; set; } = new List<Order>();
}
