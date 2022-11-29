using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceInterfaces;
public interface IOrderService {
    Task<Order> CreateOrderAsync(OrderCreationDto dto);
    Task<Order> GetOrderByIdAsync(long id);
    Task<Order> GetOrdersAsync();
}
