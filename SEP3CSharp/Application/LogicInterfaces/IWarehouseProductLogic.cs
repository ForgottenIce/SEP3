using Shared.Models;

namespace Application.LogicInterfaces;

public interface IWarehouseProductLogic
{
 Task<IEnumerable<WarehouseProduct>> GetWarehouseProductAsync();
 Task<WarehouseProduct> GetWarehouseByIdAsync(long id);
}