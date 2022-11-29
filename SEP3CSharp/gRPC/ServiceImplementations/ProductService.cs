using gRPC.ServiceInterfaces;
using Grpc.Net.Client;
using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceImplementations;
public class ProductService : IProductService {

    private readonly ProductGrpcService.ProductGrpcServiceClient _serviceClient;

    public ProductService(ProductGrpcService.ProductGrpcServiceClient grpcServiceClient) {
        _serviceClient = grpcServiceClient;
    }

    public async Task<Product> CreateProductAsync(ProductCreationDto dto) {

        ProductResponse reply = await _serviceClient.CreateProductAsync(new CreateProductRequest() {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price
        });

        Product product = new Product {
            Id = reply.Id,
            Name = reply.Name,
            Description = reply.Description,
            Price = reply.Price
        };
        return product;
    }

    public async Task<Product> GetProductByIdAsync(int id) {
        ProductResponse reply = await _serviceClient.GetProductAsync(new GetProductRequest { Id = id });

        Product product = new Product {
            Id = reply.Id,
            Name = reply.Name,
            Description = reply.Description,
            Price = reply.Price
        };
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetProductsAsync() {
        GetProductsResponse reply = await _serviceClient.GetProductsAsync(new GetProductsRequest());

        List<Product> products = new();
        foreach (ProductResponse pr in reply.Products) {
            products.Add(new Product() {
                Id = pr.Id,
                Name = pr.Name,
                Description = pr.Description,
                Price = pr.Price
            });
        }

        return products.AsEnumerable();
    }
}