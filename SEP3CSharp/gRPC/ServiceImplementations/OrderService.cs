using gRPC.ServiceInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceImplementations;
public class OrderService : IOrderService {

    private readonly OrderGrpcService.OrderGrpcServiceClient _serviceClient;

    public OrderService(OrderGrpcService.OrderGrpcServiceClient serviceClient) {
        _serviceClient = serviceClient;
    }

    public Task<Order> CreateOrderAsync(OrderCreationDto dto) {
        throw new NotImplementedException();
    }

    public Task<Order> GetOrderByIdAsync(long id) {
        throw new NotImplementedException();
    }

    public Task<Order> GetOrdersAsync() {
        throw new NotImplementedException();
    }
}
