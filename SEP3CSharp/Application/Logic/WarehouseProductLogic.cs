using Application.LogicInterfaces;
using gRPC.ServiceInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace Application.Logic;

public class WarehouseProductLogic : IWarehouseProductLogic
{
    private readonly IWarehouseProductService _warehouseProductService;

    public WarehouseProductLogic(IWarehouseProductService warehouseProductService)
    {
        _warehouseProductService = warehouseProductService;
    }

    public async Task<WarehouseProduct> CreateWarehouseProduct(WarehouseProductCreationDto dto) {
        WarehouseProduct warehouseProduct = await _warehouseProductService.CreateWarehouseProductAsync(dto);
        return warehouseProduct;
    }

    public async Task<WarehouseProduct> GetWarehouseProductByIdAsync(long id) {
        WarehouseProduct warehouseProduct = await _warehouseProductService.GetWarehouseProductByIdAsync(id);
        return warehouseProduct;
    }

    public async Task<IEnumerable<WarehouseProduct>> GetWarehouseProductsAsync() {
        IEnumerable<WarehouseProduct> warehouseProducts = await _warehouseProductService.GetWarehouseProductsAsync();
        return warehouseProducts;
    }
}