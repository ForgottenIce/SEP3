using gRPC.ServiceInterfaces;
using Shared.Models;

namespace gRPC.ServiceImplementations;
public class WarehouseService : IWarehouseService {
    private readonly WarehouseGrpcService.WarehouseGrpcServiceClient _serviceClient;

    public WarehouseService(WarehouseGrpcService.WarehouseGrpcServiceClient serviceClient) {
        _serviceClient = serviceClient;
    }

    public Task<Warehouse> GetWarehouseByIdAsync(long id) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Warehouse>> GetWarehousesAsync() {
        throw new NotImplementedException();
    }
}
