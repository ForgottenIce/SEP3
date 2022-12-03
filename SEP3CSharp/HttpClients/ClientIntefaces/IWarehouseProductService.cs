using Shared.Dtos;
using Shared.Models;

namespace HttpClients.ClientIntefaces; 

public interface IWarehouseProductService {
	Task<WarehouseProduct> CreateWarehouseProductAsync(WarehouseProductCreationDto dto);
	Task<WarehouseProduct> GetWarehouseProductById(long productId, long warehouseId);
	Task<IEnumerable<WarehouseProduct>> GetWarehouseProductsAsync();
}