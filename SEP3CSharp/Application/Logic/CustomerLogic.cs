

using Application.LogicInterfaces;

namespace Application.Logic;
using gRPC.ServiceInterfaces;
using Shared.Dtos;
using Shared.Models;

public class CustomerLogic : ICustomerLogic
{
    private readonly ICustomerLogic customerService;
    public CustomerLogic(ICustomerService customerService) {
        this.customerService = customerService;
    }


    public async Task<Customer> CreateCustomerAsync(CustomerCreationDto dto)
    {
        Customer customer = await customerService.CreateCustomerAsync(dto);
        return customer;
    }

    public Task<Customer> GetCustomerByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        IEnumerable<Customer> customers = await customerService.GetCustomersAsync();
        return customers;
    }
}
