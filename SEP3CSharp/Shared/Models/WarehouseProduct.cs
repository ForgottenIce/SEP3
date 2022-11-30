namespace Shared.Models;
public class WarehouseProduct {
    public long ProductId { get; set; }
    public long WarehouseId { get; set; }
    public int Quantity { get; set; }
    public int MinimumQuantity { get; set; }
    public string WarehousePosition { get; set; }
}
