using Shared.Dtos;
using Shared.Models;

namespace HttpClients.ClientIntefaces;

public interface IOrderService {
    Task<Order> CreateOrderAsync(OrderCreationDto dto);
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order> GetOrderByIdAsync(long id);
}
