using gRPC.ServiceInterfaces;
using Grpc.Core;
using Shared.Dtos;
using Shared.Exceptions;
using Shared.Models;
using System.Text;

namespace gRPC.ServiceImplementations;
public class OrderGrpcService : IOrderGrpcService {

    private readonly gRPC.OrderGrpcService.OrderGrpcServiceClient _serviceClient;

    public OrderGrpcService(gRPC.OrderGrpcService.OrderGrpcServiceClient serviceClient) {
        _serviceClient = serviceClient;
    }

    public async Task<Order> CreateOrderAsync(OrderCreationDto dto) {
        try {
            DateTimeOffset dtOffsetOrdered = new DateTimeOffset(dto.DateTimeOrdered ?? new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            DateTimeOffset dtOffsetSent = new DateTimeOffset(dto.DateTimeSent ?? new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            CreateOrderRequest createOrderRequest = new CreateOrderRequest {
                CustomerId = dto.CustomerId,
                DateTimeOrdered = dtOffsetOrdered.ToUnixTimeSeconds(),
                IsPacked = dto.IsPacked,
                DateTimeSent = dtOffsetSent.ToUnixTimeSeconds(),
            };
            foreach (long productId in dto.ProductIds) {
                createOrderRequest.ProductIds.Add(productId);
            }

            OrderResponse reply = await _serviceClient.CreateOrderAsync(createOrderRequest);

            Order order = new Order {
                Id = reply.Id,
                Customer = new Customer {
                    Id = reply.Customer.Id,
                    FullName = reply.Customer.Fullname,
                    PhoneNo = reply.Customer.PhoneNo,
                    Address = reply.Customer.Address,
                    Mail = reply.Customer.Mail,
                },
                DateTimeOrdered = reply.DateTimeOrdered == 0 ? null : DateTimeOffset.FromUnixTimeSeconds(reply.DateTimeOrdered).DateTime, // Set datetime to null if unix time = 0
                IsPacked = reply.IsPacked,
                DateTimeSent = reply.DateTimeSent == 0 ? null : DateTimeOffset.FromUnixTimeSeconds(reply.DateTimeSent).DateTime
            };
            return order;
        }
        catch (RpcException e) {
            if (e.StatusCode == StatusCode.Unavailable) {
                throw new ServiceUnavailableException();
            }
            if (e.StatusCode == StatusCode.NotFound) {
                var trailer = e.Trailers.Get("grpc.reflection.v1alpha.errorresponse-bin")!;
                throw new NotFoundException(e.Status.Detail + "\nDetails: " + Encoding.UTF8.GetString(trailer.ValueBytes).Substring(2));
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
                DateTimeOrdered = reply.DateTimeOrdered == 0 ? null : DateTimeOffset.FromUnixTimeSeconds(reply.DateTimeOrdered).DateTime, // Set datetime to null if unix time = 0
                IsPacked = reply.IsPacked,
                DateTimeSent = reply.DateTimeSent == 0 ? null : DateTimeOffset.FromUnixTimeSeconds(reply.DateTimeSent).DateTime
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
                    DateTimeOrdered = or.DateTimeOrdered == 0 ? null : DateTimeOffset.FromUnixTimeSeconds(or.DateTimeOrdered).DateTime, // Set datetime to null if unix time = 0
                    IsPacked = or.IsPacked,
                    DateTimeSent = or.DateTimeSent == 0 ? null : DateTimeOffset.FromUnixTimeSeconds(or.DateTimeSent).DateTime
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
