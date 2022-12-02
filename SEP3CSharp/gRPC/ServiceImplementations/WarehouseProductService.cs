using Grpc.Core;
using gRPC.ServiceInterfaces;
using Shared.Dtos;
using Shared.Exceptions;
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
        try {
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
        catch (RpcException e) {
            if (e.StatusCode == StatusCode.Unavailable) {
                throw new ServiceUnavailableException();
            }
            if (e.StatusCode == StatusCode.NotFound) {
                throw new NotFoundException(e.Status.Detail);
            }

            if (e.StatusCode == StatusCode.AlreadyExists) {
                throw new AlreadyExistsException(e.Status.Detail);
            }
            throw e;
        }
    }
    
    
    public async Task<WarehouseProduct> GetWarehouseProductByIdAsync(long id)
    {
        try {
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
            return warehouseProduct;
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
    

    public async Task<IEnumerable<WarehouseProduct>> GetWarehouseProductsAsync()
    {
        try {
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
        catch (RpcException e) {
            if (e.StatusCode == StatusCode.Unavailable) {
                throw new ServiceUnavailableException();
            }
            
            throw e;
        }
    }
}
