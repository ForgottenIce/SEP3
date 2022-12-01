using Shared.Models;

namespace gRPC.ServiceInterfaces;
public interface IWarehouseService {
    Task <IEnumerable<Warehouse>> GetWarehousesAsync();
    Task <Warehouse> GetWarehouseByIdAsync(long id);
}
