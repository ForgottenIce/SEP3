using Application.LogicInterfaces;
using gRPC.ServiceInterfaces;
using Shared.Models;

namespace Application.Logic;
public class WarehouseLogic : IWarehouseLogic {
    private readonly IWarehouseService _warehouseService;

    public WarehouseLogic(IWarehouseService warehouseService) {
        _warehouseService = warehouseService;
    }

    public Task<Warehouse> GetWarehouseByIdAsync(long id) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Warehouse>> GetWarehousesAsync() {
        throw new NotImplementedException();
    }
}
