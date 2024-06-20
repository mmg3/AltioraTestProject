namespace Altiora.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ArticleId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
