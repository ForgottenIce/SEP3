using gRPC.ServiceInterfaces;
using Shared.Models;

namespace gRPC.ServiceImplementations;
public class WarehouseService : IWarehouseService {
    private readonly WarehouseGrpcService.WarehouseGrpcServiceClient _serviceClient;

    public WarehouseService(WarehouseGrpcService.WarehouseGrpcServiceClient serviceClient) {
        _serviceClient = serviceClient;
    }

    public async Task<Warehouse> GetWarehouseByIdAsync(long id) {
        WarehouseResponse reply = await _serviceClient.GetWarehouseAsync(new GetWarehouseRequest { WarehouseId = id });

        Warehouse warehouse = new Warehouse {
            Id = reply.WarehouseId,
            Address = reply.Address,
            Name = reply.Name
        };
        return warehouse;
    }

    public Task<IEnumerable<Warehouse>> GetWarehousesAsync() {
        throw new NotImplementedException();
    }
}
