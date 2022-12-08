using Shared.Dtos;
using Shared.Models;

namespace Application.LogicInterfaces;
public interface IOrderLogic {
    Task<Order> CreateOrderAsync(OrderCreationDto dto);
    Task<Order> GetOrderByIdAsync(long id);
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<IEnumerable<Order>> GetOrdersByWarehouseIdAsync(long id);
}
