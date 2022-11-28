using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceInterfaces;
public interface IProductService {
    Task<Product> CreateProductAsync(ProductCreationDto dto);
    Task<IEnumerable<Product>> GetProductsAsync();
}