namespace Altiora.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Code { get; set; } = null!;

    public int ClientId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Client Client { get; set; } = null!;
}
