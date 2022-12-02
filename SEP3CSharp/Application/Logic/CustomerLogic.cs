using Application.LogicInterfaces;
using gRPC.ServiceInterfaces;
using Shared.Models;

namespace Application.Logic;


public class CustomerLogic : ICustomerLogic
{
    private readonly ICustomerLogic _customerService;

    public CustomerLogic(ICreateCustomerService cutomerService)
    {
        _customerService = cutomerService;
    }

    public async Task<IEnumerable<Customer>> GetCustomerAsync()
    {
        IEnumerable<Customer> customers = await _customerService.GetCustomerAsync();
        return customers;
    }

    public Task<Customer> GetCustomerByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
