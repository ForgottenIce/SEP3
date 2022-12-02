﻿using gRPC.ServiceInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceImplementations;

public class CustomerService : ICustomerService
{
    private readonly CustomersGrpcService.CustomersGrpcServiceClient _serviceClient;

    public CustomerService(CustomersGrpcService.CustomersGrpcServiceClient serviceClient)
    {
        _serviceClient = serviceClient;
    }

    public async Task<Customer> CreateCustomerAsync(CustomerCreationDto dto)
    {
        CustomerResponse replay = await _serviceClient.CreateCustomerAsync(new CreateCustomerRequest()
        { 
            Fullname = dto.FullName,
            PhoneNo = dto.PhoneNo,
            Address = dto.Address,
            Mail = dto.Mail
        });
        Customer customer = new Customer()
        {
            FullName = replay.Fullname,
            PhoneNo = replay.PhoneNo,
            Address = replay.Address,
            Mail = replay.Mail
        };
        return customer;
    }
//TODO
    public Task<IEnumerable<Customer>> GetCustomerAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        GetCustomersResponse replay = await _serviceClient.GetCustomersAsync(new GetCustomersRequest());

        List<Customer> customers = new();
        foreach (CustomerResponse pr in replay.Customers)
        {
            customers.Add(new Customer()
                {
                    Id = pr.Id,
                    Address = pr.Address,
                    FullName = pr.Fullname,
                    Mail = pr.Mail,
                    PhoneNo = pr.PhoneNo
                });
        }

        return customers.AsEnumerable();
    }

    public async Task<Customer> GetCustomerById(int id)
    {
        CustomerResponse replay = await _serviceClient.GetCustomerAsync(new GetCustomerRequest()
        {
            Id = id
        });

        Customer customer = new Customer()

            {
                Id = replay.Id,
                FullName = replay.Fullname,
                PhoneNo = replay.PhoneNo,
                Address = replay.Address,
                Mail = replay.Mail
            };

        return customer;
    }
    
}