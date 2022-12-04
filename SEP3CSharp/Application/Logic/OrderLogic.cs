using Application.LogicInterfaces;
using gRPC.ServiceInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace Application.Logic;
public class OrderLogic : IOrderLogic {
    private readonly IOrderGrpcService _orderService;

    public OrderLogic(IOrderGrpcService orderService) {
        _orderService = orderService;
    }

    public Task<Order> CreateOrderAsync(OrderCreationDto dto) {
        throw new NotImplementedException();
    }

    public Task<Order> GetOrderByIdAsync(long id) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetOrdersAsync() {
        throw new NotImplementedException();
    }
}
