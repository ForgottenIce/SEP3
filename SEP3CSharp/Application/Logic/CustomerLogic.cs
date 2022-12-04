using Application.LogicInterfaces;
using gRPC.ServiceInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace Application.Logic;

public class CustomerLogic : ICustomerLogic
{
    private readonly ICustomerService customerService;
    public CustomerLogic(ICustomerService customerService) {
        this.customerService = customerService;
    }

    public async Task<Customer> CreateCustomerAsync(CustomerCreationDto dto)
    {
        Customer customer = await customerService.CreateCustomerAsync(dto);
        return customer;
    }

    public async Task<Customer> GetCustomerByIdAsync(long id)
    {
        Customer customer = await customerService.GetCustomerByIdAsync(id);
        return customer;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        IEnumerable<Customer> customers = await customerService.GetCustomersAsync();
        return customers;
    }
}
