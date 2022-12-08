﻿using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceInterfaces;

public interface ICustomerGrpcService
{
    Task<Customer> CreateCustomerAsync(CustomerCreationDto dto);
    Task<Customer> GetCustomerByIdAsync(long id);
    Task<IEnumerable<Customer>> GetCustomersAsync();
}