namespace Shared.Models;
public class WarehouseProduct {
    public int ProductId { get; set; }
    public int WarehouseiD { get; set; }
    public int Quantity { get; set; }
    public int MinimumQuantity { get; set; }
    public string Shelf { get; set; }
    public int ShelfSection { get; set; }
}
