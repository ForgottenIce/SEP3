using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceInterfaces;

public interface ICustomerService
{
    Task<Customer> CreateCustomerAsync(CustomerCreationDto dto);
    Task<IEnumerable<Customer>> GetCustomerAsync();
    Task<Customer> GetCustomerById(int id);

    Task<IEnumerable<Customer>> GetCustomersAsync();
}