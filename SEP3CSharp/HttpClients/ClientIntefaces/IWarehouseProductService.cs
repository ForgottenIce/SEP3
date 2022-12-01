using Shared.Dtos;
using Shared.Models;

namespace HttpClients.ClientIntefaces;

public interface IWarehouseProductService
{
    Task<WarehouseProduct> CreateWarehouseProductAsync(WarehouseProductDto dto);
    Task<IEnumerable<WarehouseProduct>> GetWarehouseProductsAsync();
}   