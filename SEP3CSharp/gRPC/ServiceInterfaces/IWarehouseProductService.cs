using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceInterfaces;

public interface IWarehouseProductService
{
    Task<WarehouseProduct> CreateWarehouseProductAsync(WarehouseProductDto dto);
    Task<IEnumerable<WarehouseProduct>> GetWarehouseProductsAsync();
}   