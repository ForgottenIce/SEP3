using Application.LogicInterfaces;
using gRPC.ServiceInterfaces;
using Shared.Models;

namespace Application.Logic;

public class WarehouseProductLogic : IWarehouseProductLogic
{
    private readonly IWarehouseProductService _warehouseProductService;

    public WarehouseProductLogic(IWarehouseProductService warehouseProductService)
    {
        this._warehouseProductService = warehouseProductService;
    }

    public Task<WarehouseProduct> GetWarehouseProductByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<WarehouseProduct>> GetWarehouseProductsAsync()
    {
        throw new NotImplementedException();
    }
}