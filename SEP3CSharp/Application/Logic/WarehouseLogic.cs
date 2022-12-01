using Application.LogicInterfaces;
using gRPC.ServiceInterfaces;
using Shared.Exceptions;
using Shared.Models;

namespace Application.Logic;
public class WarehouseLogic : IWarehouseLogic {
    private readonly IWarehouseService _warehouseService;

    public WarehouseLogic(IWarehouseService warehouseService) {
        _warehouseService = warehouseService;
    }

    public async Task<Warehouse> GetWarehouseByIdAsync(long id) {
        Warehouse warehouse = await _warehouseService.GetWarehouseByIdAsync(id);
        return warehouse;
    }

    public async Task<IEnumerable<Warehouse>> GetWarehousesAsync() {
        IEnumerable<Warehouse> warehouses = await _warehouseService.GetWarehousesAsync();
        return warehouses;
    }
}
