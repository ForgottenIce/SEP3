using gRPC.ServiceInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceImplementations;

public class WarehouseProductService : IWarehouseProductService
{
    private readonly WarehouseProductGrpcService.WarehouseProductGrpcServiceClient _warehouseProductGrpcServiceClient;

    public WarehouseProductService(WarehouseProductGrpcService.WarehouseProductGrpcServiceClient warehouseProductGrpcServiceClient)
    {
        _warehouseProductGrpcServiceClient = warehouseProductGrpcServiceClient;
    }

   

    public async Task<WarehouseProduct> CreateWarehouseProductAsync(WarehouseProductCreationDto dto)
    {
        WarehouseProductResponse replay = await _warehouseProductGrpcServiceClient.CreateWarehouseProductAsync(
            new CreateWarehouseProductRequest()
            {
                WarehouseId = dto.WarehouseId,
                WarehousePosition = dto.WarehousePosition,
                MinimumQuantity = dto.MinimumQuantity,
                Quantity = dto.Quantity,
                ProductId = dto.ProductId
            });

        WarehouseProduct warehouseProduct = new WarehouseProduct()
        {
            WarehouseId = replay.WarehouseId,
            WarehousePosition = replay.WarehousePosition,
            MinimumQuantity = replay.MinimumQuantity,
            Quantity = replay.Quantity,
            ProductId = replay.ProductId

        };
        return warehouseProduct;
    }
    
    
    public async Task<WarehouseProduct> GetWarehouseProductByIdAsync(int id)
    {
        WarehouseProductResponse replyTo =
            await _warehouseProductGrpcServiceClient.GetWarehouseProductAsync(new GetWarehouseProductRequest
                { WarehouseId = id });

        WarehouseProduct warehouseProduct = new WarehouseProduct
        {
            WarehouseId = replyTo.WarehouseId,
            WarehousePosition = replyTo.WarehousePosition,
            MinimumQuantity = replyTo.MinimumQuantity,
            Quantity = replyTo.Quantity,
            ProductId = replyTo.ProductId
            
        };
        throw new NotImplementedException(); //???
    }
    

    public async Task<IEnumerable<WarehouseProduct>> GetWarehouseProductsAsync()
    {
        GetWarehouseProductsResponse reply = await _warehouseProductGrpcServiceClient.GetWarehouseProductsAsync(new GetWarehouseProductsRequest());
       
        
        List<WarehouseProduct> warehouseProducts = new();
        foreach (WarehouseProductResponse pr in reply.WarehouseProducts)
        {
            warehouseProducts.Add(new WarehouseProduct()
            {
                WarehouseId = pr.WarehouseId,
                WarehousePosition = pr.WarehousePosition,
                MinimumQuantity = pr.MinimumQuantity,
                Quantity = pr.Quantity,
                ProductId = pr.ProductId
            });
        }

        return warehouseProducts.AsEnumerable();
    }
}
