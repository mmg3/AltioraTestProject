using System;
using System.Collections.Generic;

namespace Altiora.Models;

public partial class ClientDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Identification { get; set; } = null!;

    public string? Email { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<OrderDto> Orders { get; set; } = new List<OrderDto>();
}
