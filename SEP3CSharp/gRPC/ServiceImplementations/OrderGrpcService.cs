using gRPC.ServiceInterfaces;
using Grpc.Core;
using Shared.Dtos;
using Shared.Exceptions;
using Shared.Models;

namespace gRPC.ServiceImplementations;
public class OrderGrpcService : IOrderGrpcService {

    private readonly gRPC.OrderGrpcService.OrderGrpcServiceClient _serviceClient;

    public OrderGrpcService(gRPC.OrderGrpcService.OrderGrpcServiceClient serviceClient) {
        _serviceClient = serviceClient;
    }

    public async Task<Order> CreateOrderAsync(OrderCreationDto dto) {
        try {
            DateTimeOffset dtOffsetOrdered = new DateTimeOffset(dto.DateTimeOrdered);
            DateTimeOffset dtOffsetSent = new DateTimeOffset(dto.DateTimeSent);
            OrderResponse reply = await _serviceClient.CreateOrderAsync(new CreateOrderRequest {
                CustomerId = dto.Customer.Id,
                DateTimeOrdered = dtOffsetOrdered.ToUnixTimeSeconds(),
                IsPacked = dto.IsPacked,
                DateTimeSent = dtOffsetSent.ToUnixTimeSeconds(),
            });

            Order order = new Order {
                Id = reply.Id,
                Customer = new Customer {
                    Id = reply.Customer.Id,
                    FullName = reply.Customer.Fullname,
                    PhoneNo = reply.Customer.PhoneNo,
                    Address = reply.Customer.Address,
                    Mail = reply.Customer.Mail,
                },
                DateTimeOrdered = DateTimeOffset.FromUnixTimeSeconds(reply.DateTimeOrdered).DateTime,
                IsPacked = reply.IsPacked,
                DateTimeSent = DateTimeOffset.FromUnixTimeSeconds(reply.DateTimeSent).DateTime
            };
            return order;
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

    public async Task<Order> GetOrderByIdAsync(long id) {
        try {
            OrderResponse reply = await _serviceClient.GetOrderAsync(new GetOrderRequest { Id = id });

            Order order = new Order {
                Id = reply.Id,
                Customer = new Customer {
                    Id = reply.Customer.Id,
                    FullName = reply.Customer.Fullname,
                    PhoneNo = reply.Customer.PhoneNo,
                    Address = reply.Customer.Address,
                    Mail = reply.Customer.Mail,
                },
                DateTimeOrdered = DateTimeOffset.FromUnixTimeSeconds(reply.DateTimeOrdered).DateTime,
                IsPacked = reply.IsPacked,
                DateTimeSent = DateTimeOffset.FromUnixTimeSeconds(reply.DateTimeSent).DateTime
            };
            return order;
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

    public async Task<IEnumerable<Order>> GetOrdersAsync() {
        try {
            GetOrdersResponse reply = await _serviceClient.GetOrdersAsync(new GetOrdersRequest());

            List<Order> orders = new();
            foreach (OrderResponse or in reply.Orders) {
                orders.Add(new Order {
                    Id = or.Id,
                    Customer = new Customer {
                        Id = or.Customer.Id,
                        FullName = or.Customer.Fullname,
                        PhoneNo = or.Customer.PhoneNo,
                        Address = or.Customer.Address,
                        Mail = or.Customer.Mail,
                    },
                    DateTimeOrdered = DateTimeOffset.FromUnixTimeSeconds(or.DateTimeOrdered).DateTime,
                    IsPacked = or.IsPacked,
                    DateTimeSent = DateTimeOffset.FromUnixTimeSeconds(or.DateTimeSent).DateTime
                });
            }
            
            return orders.AsEnumerable();
        }
        catch (RpcException e) {
            if (e.StatusCode == StatusCode.Unavailable) {
                throw new ServiceUnavailableException();
            }
            throw e;
        }
    }
}
