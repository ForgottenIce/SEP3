using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceInterfaces;
public interface IOrderGrpcService {
    Task<Order> CreateOrderAsync(OrderCreationDto dto);
    Task<Order> GetOrderByIdAsync(long id);
    Task<IEnumerable<Order>> GetOrdersAsync();
}
