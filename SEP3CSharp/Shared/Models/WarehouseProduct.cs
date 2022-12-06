namespace Shared.Models;
public class WarehouseProduct {
    public Product ProductId { get; set; }
    public Warehouse WarehouseId { get; set; }
    public int Quantity { get; set; }
    public int MinimumQuantity { get; set; }
    public string WarehousePosition { get; set; }
}
