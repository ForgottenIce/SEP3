namespace Shared.Dtos;

public class WarehouseProductCreationDto
{
    public long ProductId { get;}
    public long WarehouseId { get;}
    public int Quantity { get;}
    public int MinimumQuantity { get;}
    public string WarehousePosition { get;}

    public WarehouseProductCreationDto(long productId, long warehouseId, int quantity, int minimumQuantity, string warehousePosition)
    {
        ProductId = productId;
        WarehouseId = warehouseId;
        Quantity = quantity;
        MinimumQuantity = minimumQuantity;
        WarehousePosition = warehousePosition;
    }
}