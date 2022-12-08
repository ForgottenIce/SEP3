namespace Shared.Models;
public class WarehouseProduct {
    public Product Product { get; set; }
    public Warehouse Warehouse { get; set; }
    public int Quantity { get; set; }
    public int MinimumQuantity { get; set; }
    public string WarehousePosition { get; set; }
}
