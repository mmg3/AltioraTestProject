using System;
using System.Collections.Generic;

namespace Altiora.Dtos;

public partial class ArticleDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public bool IsDeleted { get; set; }
}
