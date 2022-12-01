using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceInterfaces;

public interface IWarehouseProductService
{
    Task<WarehouseProduct> CreateWarehouseProductAsync(WarehouseProductCreationDto dto);
    Task<IEnumerable<WarehouseProduct>> GetWarehouseProductsAsync();
}   