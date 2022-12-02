namespace Shared.Models;
public class WarehouseProduct {
    public long ProductId { get; set; } //TODO make these object references
    public long WarehouseId { get; set; } //TODO make these object references
    public int Quantity { get; set; }
    public int MinimumQuantity { get; set; }
    public string WarehousePosition { get; set; }
}
