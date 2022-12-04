using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceInterfaces;

public interface ICustomerService
{
    Task<Customer> CreateCustomerAsync(CustomerCreationDto dto);
    Task<Customer> GetCustomerByIdAsync(long id);
    Task<IEnumerable<Customer>> GetCustomersAsync();
}