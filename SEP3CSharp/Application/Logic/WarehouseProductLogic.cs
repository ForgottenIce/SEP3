using Application.LogicInterfaces;
using gRPC.ServiceInterfaces;
using Shared.Models;

namespace Application.Logic;

public class WarehouseProductLogic : IWarehouseProductLogic
{
    private readonly IWarehouseProductService _warehouseProductService;

    public WarehouseProductLogic(IWarehouseProductService warehouseProductServise)
    {
        this._warehouseProductService = warehouseProductServise;
    }

    public Task<WarehouseProduct> GetWarehouseProductByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<WarehouseProduct>> GetWarehouseProductAsync()
    {
        throw new NotImplementedException();
    }
}