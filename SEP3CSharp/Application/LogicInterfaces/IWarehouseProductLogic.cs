using Shared.Models;

namespace Application.LogicInterfaces;
public interface IWarehouseProductLogic {
    Task<WarehouseProduct> GetWarehouseProductByIdAsync(long id);
    Task<IEnumerable<WarehouseProduct>> GetWarehouseProductsAsync();
}
