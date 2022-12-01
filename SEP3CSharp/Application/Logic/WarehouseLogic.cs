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
        try {
            Warehouse warehouse = await _warehouseService.GetWarehouseByIdAsync(id);
            return warehouse;
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw new NotFoundException(new Warehouse());
        }
    }

    public Task<IEnumerable<Warehouse>> GetWarehousesAsync() {
        throw new NotImplementedException();
    }
}
