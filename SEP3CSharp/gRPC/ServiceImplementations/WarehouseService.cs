using gRPC.ServiceInterfaces;
using Grpc.Core;
using Shared.Exceptions;
using Shared.Models;

namespace gRPC.ServiceImplementations;
public class WarehouseService : IWarehouseService {
    private readonly WarehouseGrpcService.WarehouseGrpcServiceClient _serviceClient;

    public WarehouseService(WarehouseGrpcService.WarehouseGrpcServiceClient serviceClient) {
        _serviceClient = serviceClient;
    }

    public async Task<Warehouse> GetWarehouseByIdAsync(long id) {
        try {
            WarehouseResponse reply = await _serviceClient.GetWarehouseAsync(new GetWarehouseRequest { WarehouseId = id });

            Warehouse warehouse = new Warehouse {
                Id = reply.WarehouseId,
                Address = reply.Address,
                Name = reply.Name
            };
            return warehouse;
        }
        catch (RpcException e) {
            if (e.StatusCode == StatusCode.Unavailable) {
                throw new ServiceUnavailableException();
            }
            if (e.StatusCode == StatusCode.NotFound) {
                throw new NotFoundException(e.Status.Detail);
            }
            throw e;
        }
    }

    public async Task<IEnumerable<Warehouse>> GetWarehousesAsync() {
        try {
            GetWarehousesResponse reply = await _serviceClient.GetWarehousesAsync(new GetWarehousesRequest());

            List<Warehouse> warehouses = new();
            foreach (WarehouseResponse wr in reply.Warehouses) {
                warehouses.Add(new Warehouse() {
                    Id = wr.WarehouseId,
                    Name= wr.Name,
                    Address = wr.Address,
                });
            }

            return warehouses.AsEnumerable();
        }
        catch (RpcException e) {
            if (e.StatusCode == StatusCode.Unavailable) {
                throw new ServiceUnavailableException();
            }
            throw e;
        }
    }
}
